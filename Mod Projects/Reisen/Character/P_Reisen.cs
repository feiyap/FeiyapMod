using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using GameDataEditor;
using I2.Loc;
using DarkTonic.MasterAudio;
using ChronoArkMod;
using ChronoArkMod.Plugin;
using ChronoArkMod.Template;
using Debug = UnityEngine.Debug;
namespace Reisen
{
	/// <summary>
	/// 铃仙·优昙华院
	/// Passive:
	/// 幻象/乱弹：战斗开始时，获得6颗[子弹]。
	/// 铃仙使用攻击技能指向敌人时，自动消耗1颗[子弹]，对目标进行1次[幻象/乱弹]（如果是群体范围，选取随机目标）。
	/// [幻象/乱弹]为追加攻击，基础只有50%命中率和(30%)伤害。
	/// 每次按下[等待]按钮时，获得1颗[子弹]。
	/// 幻象/狂气：战斗开始时，获得4层[狂气]。
	/// 铃仙的固定技能被替换为[长视「赤月下(Infrared Moon)」]：消耗1层[狂气]，进入[幻象/赤月]状态。
	/// 在[幻象/赤月]状态下，铃仙的[幻象/乱弹]和手中的技能获得增强和额外效果，但使用技能时会消耗[狂气]的层数。[狂气]层数清空时退出[幻象/赤月]状态。
	/// </summary>
    public class P_Reisen:Passive_Char, IP_BattleStart_Ones, IP_SkillUse_Target, IP_WaitButton, IP_SkillUseHand_Team, IP_PlayerTurn
    {
        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
        }
        
        //战斗开始时获得4狂气6子弹
        public void BattleStart(BattleSystem Ins)
        {
            for (int i = 0;i<6;i++)
            {
                this.BChar.BuffAdd("B_Reisen_P_Bullet", this.BChar, false, 0, false, -1, false);
            }
            for (int i = 0;i<4;i++)
            {
                this.BChar.BuffAdd("B_Reisen_P_Insane", this.BChar, false, 0, false, -1, false);
            }
        }

        //使用技能时重置固有CD
        public void SKillUseHand_Team(Skill skill)
        {
            BattleSystem.DelayInputAfter(this.Del(skill));
        }
        
        //执行协程-重置固有
        private IEnumerator Del(Skill skill)
        {
            this.BChar.MyTeam.BasicSkillRefill(this.BChar, this.BChar.BattleBasicskillRefill);

            yield break;
        }

        //命中时诱发乱弹
        public void AttackEffect(BattleChar hit, SkillParticle SP, int DMG, bool Cri)
        {
            if (SP.UseStatus == this.BChar && !SP.SkillData.PlusHit && !SP.SkillData.FreeUse && SP.ALLTARGET.Count == 1 && hit.Info.Ally != this.BChar.Info.Ally)
            {
                if (this.BChar.BuffReturn("B_Reisen_P_Bullet").StackNum >= 1)
                {
                    BattleSystem.DelayInputAfter(this.Ienum(hit));
                }
            }
        }

        //执行协程-乱弹
        public IEnumerator Ienum(BattleChar hit)
        {
            Skill skill;
            if (this.BChar.BuffFind("B_Reisen_6"))
            {
                skill = Skill.TempSkill("S_Reisen_P_2", this.BChar, this.BChar.MyTeam);
                if (!this.BChar.BuffFind("B_Reisen_11Rare"))
                {
                    this.BChar.BuffReturn("B_Reisen_P_Insane").SelfStackDestroy();
                }
            }
            else if (this.BChar.BuffFind("B_Reisen_P"))
            {
                skill = Skill.TempSkill("S_Reisen_P_1", this.BChar, this.BChar.MyTeam);
                if (!this.BChar.BuffFind("B_Reisen_11Rare"))
                {
                    this.BChar.BuffReturn("B_Reisen_P_Insane").SelfStackDestroy();
                }
            }
            else
            {
                skill = Skill.TempSkill("S_Reisen_P_0", this.BChar, this.BChar.MyTeam);
            }

            skill.isExcept = true;
            skill.FreeUse = true;
            skill.PlusHit = true;
            skill.NoAttackTimeWait = true;

            if (hit.BuffFind("B_Reisen_2"))
            {
                Skill_Extended skill_Extended = new Skill_Extended();
                skill_Extended.PlusSkillStat.hit += 100f;
                skill.ExtendedAdd(skill_Extended);
            }
            if (hit.BuffFind("B_Reisen_2_0"))
            {
                Skill_Extended skill_Extended = new Skill_Extended();
                skill_Extended.PlusSkillStat.cri += 100f;
                skill.ExtendedAdd(skill_Extended);
            }

            this.BChar.BuffReturn("B_Reisen_P_Bullet").SelfStackDestroy();

            yield return new WaitForSecondsRealtime(0.1f);

            this.BChar.ParticleOut(skill, hit);

            CheckInsane();

            yield break;
        }

        //等待时装弹
        public void UseWaitButton()
        {
            this.BChar.BuffAdd("B_Reisen_P_Bullet", this.BChar, false, 0, false, -1, false);

            if (this.BChar.BuffFind("B_Reisen_P"))
            {
                this.BChar.BuffReturn("B_Reisen_P").SelfDestroy();
            }
        }

        //判断狂气是否为0
        public void CheckInsane()
        {
            if (!this.BChar.BuffFind("B_Reisen_P_Insane"))
            {
                if (this.BChar.BuffFind("B_Reisen_6"))
                {
                    this.BChar.BuffReturn("B_Reisen_6").SelfDestroy();
                }
                else if (this.BChar.BuffFind("B_Reisen_P"))
                {
                    this.BChar.BuffReturn("B_Reisen_P").SelfDestroy();
                }
            }
        }

        //回合开始时获得狂气
        public void Turn()
        {
            this.BChar.BuffAdd("B_Reisen_P_Insane", this.BChar, false, 0, false, -1, false);
        }
    }
}