using ChronoArkMod;
using ChronoArkMod.Plugin;
using ChronoArkMod.Template;
using DarkTonic.MasterAudio;
using GameDataEditor;
using I2.Loc;
using Spine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;
namespace FeiyapTank
{
    /// <summary>
    /// 嬉笑魔女
    /// 调查员交替使用攻击技能和治疗技能时，获得 1 层“百巧手”。
    /// </summary>
    public class B_Boss_FeiyapMage_P : Buff, IP_BattleStart_UIOnBefore, IP_BattleStart_Ones, IP_HPChange, IP_SkillUseHand_Team
    {
        public int Phase = 1;
        public int SkillType = 0; //0:无，1：攻击，2：治疗

        //处理战斗事件
        public void BattleStartUIOnBefore(BattleSystem Ins)
        {
            BattleSystem.DelayInput(this.Start1());

            BattleSystem.instance.Reward.Add(ItemBase.GetItem("R_Boss_FeiyapMage_0"));
            BattleSystem.instance.Reward.Add(ItemBase.GetItem("E_Boss_FeiyapMage_0"));
        }

        //开场对话
        public IEnumerator Start1()
        {
            MasterAudio.StopBus("BGM");
            MasterAudio.StopBus("BattleBGM");
            MasterAudio.FadeBusToVolume("BGM", 1f, 1f, null, false, false);
            MasterAudio.FadeBusToVolume("BattleBGM", 0f, 0.5f, null, false, false);

            {
                yield return BattleText.InstBattleText_Co(this.BChar, ModManager.getModInfo("FeiyapTank").localizationInfo.SystemLocalizationUpdate("BattleDia/Boss_FeiyapMage/Text1"), true, 0, 0f);
                yield return BattleText.InstBattleText_Co(this.BChar, ModManager.getModInfo("FeiyapTank").localizationInfo.SystemLocalizationUpdate("BattleDia/Boss_FeiyapMage/Text2"), true, 0, 0f);
                yield return BattleText.InstBattleText_Co(this.BChar, ModManager.getModInfo("FeiyapTank").localizationInfo.SystemLocalizationUpdate("BattleDia/Boss_FeiyapMage/Text3"), true, 0, 0f);
            }

            MasterAudio.PlaySound("Boss_FeiyapMage", 1f, null, 0f, null, null, false, false);

            yield break;
        }

        public override void Init()
        {
            base.Init();
        }

        public void BattleStart(BattleSystem Ins)
        {
            Ins.BattleExtended.Add(new BattleEvent_FeiyapMage());
            BattleEvent_FeiyapMage.Boss = this.BChar;
            BattleEvent_FeiyapMage.MainP = this;
            BattleEvent_FeiyapMage.SuperHand = 0;
            Phase = 1;
        }

        public void HPChange(BattleChar Char, bool Healed)
        {
            if (Char == this.BChar && !Healed)
            {
                if (this.BChar.HP <= this.BChar.GetStat.maxhp / 2 && Phase == 1)
                {
                    //进入惩罚阶段
                    BattleSystem.DelayInput(this.Phase2());

                    Phase = 2;

                    //int lastAct = 0;
                    //foreach (CastingSkill cs in BattleSystem.instance.EnemyCastSkills)
                    //{
                    //    if (cs.skill.Master == this.BChar && cs.CastSpeed > lastAct)
                    //    {
                    //        lastAct = cs.CastSpeed;
                    //    }
                    //}

                    //List<BattleChar> list = new List<BattleChar>();
                    //Skill skill = Skill.TempSkill("S_Boss_FeiyapMage_3", this.BChar, this.BChar.MyTeam);
                    //list.AddRange((this.BChar as BattleEnemy).Ai.TargetSelect(skill));
                    //BattleSystem.instance.EnemyCastEnqueue(this.BChar as BattleEnemy, skill, list, lastAct + 2 + BattleSystem.instance.AllyTeam.TurnActionNum, false);
                }
            }
        }
        public IEnumerator Phase2()
        {
            MasterAudio.StopBus("BGM");
            MasterAudio.StopBus("BattleBGM");
            MasterAudio.FadeBusToVolume("BGM", 1f, 1f, null, false, false);
            MasterAudio.FadeBusToVolume("BattleBGM", 0f, 0.5f, null, false, false);

            {
                yield return BattleText.InstBattleText_Co(this.BChar, ModManager.getModInfo("FeiyapTank").localizationInfo.SystemLocalizationUpdate("BattleDia/Boss_FeiyapMage/Text4"), true, 0, 0f);
                yield return BattleText.InstBattleText_Co(this.BChar, ModManager.getModInfo("FeiyapTank").localizationInfo.SystemLocalizationUpdate("BattleDia/Boss_FeiyapMage/Text5"), true, 0, 0f);
                yield return BattleText.InstBattleText_Co(this.BChar, ModManager.getModInfo("FeiyapTank").localizationInfo.SystemLocalizationUpdate("BattleDia/Boss_FeiyapMage/Text6"), true, 0, 0f);
            }

            MasterAudio.PlaySound("Boss_FeiyapMage_2", 1f, null, 0f, null, null, false, false);

            Skill skill = Skill.TempSkill("S_Boss_FeiyapMage_3", this.BChar, this.BChar.MyTeam);
            List<BattleChar> list = new List<BattleChar>();
            list.AddRange((this.BChar as BattleEnemy).Ai.TargetSelect(skill));
            this.BChar.ParticleOut(skill, list);

            BattleSystem.instance.TurnNum += 5;

            BattleSystem.instance.TurnAni.gameObject.SetActive(true);
            BattleSystem.instance.TurnAni.Play("TurnUpdate", 0, 0f);
            BattleSystem.instance.TurnText.text = BattleSystem.instance.TurnNum.ToString();
            BattleSystem.instance.MainMist.MistAni.SetInteger("Phase", BattleSystem.instance.FogTurn - BattleSystem.instance.TurnNum);
            if (BattleSystem.instance.FogTurn <= BattleSystem.instance.TurnNum)
            {
                BattleSystem.instance.MistAni.Play("MistOn");
            }

            yield break;
        }

        public void SKillUseHand_Team(Skill skill)
        {
            if (skill.Master.Info.Ally)
            {
                if (skill.IsHeal)
                {
                    if (SkillType == 1)
                    {
                        BattleEvent_FeiyapMage.SuperHand++;
                    }
                    SkillType = 2;
                }
                else if (skill.IsDamage)
                {
                    if (SkillType == 2)
                    {
                        BattleEvent_FeiyapMage.SuperHand++;
                    }
                    SkillType = 1;
                }
                else
                {
                    SkillType = 0;
                }
            }
        }
    }
}