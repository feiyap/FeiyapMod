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
namespace IzayoiSakuya
{
	/// <summary>
	/// 速符「闪光弹跳」
	/// 月魔术：降低1点费用。打出时使随机一个敌人的倒计时技能无效化。
	/// </summary>
    public class S_Sakuya_1:Skill_Extended
    {
        public bool flag;

        public override void Init()
        {
            base.Init();
            this.SkillParticleObject = new GDESkillExtendedData(GDEItemKeys.SkillExtended_Public_1_Ex).Particle_Path;
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            if (BattleSystem.instance != null && BattleSystem.instance.AllyTeam.Skills.Count != 0)
            {
                flag = false;
                base.SkillParticleOff();
                this.MySkill.MySkill.Name = "速符「闪光弹跳」";
                this.APChange = 0;
                this.IgnoreTaunt = false;
                if (this.MySkill == BattleSystem.instance.AllyTeam.Skills[BattleSystem.instance.AllyTeam.Skills.Count - 1]
                    || this.MySkill == BattleSystem.instance.AllyTeam.Skills[0]
                    || this.MySkill.ExtendedFind_DataName("SE_Sakuya_7") != null
                    || this.BChar.BuffFind("B_Sakuya_12Rare"))
                {
                    flag = true;
                    base.SkillParticleOn();
                    this.MySkill.MySkill.Name = "光速「光速跃迁」";
                    this.APChange = -1;
                    this.IgnoreTaunt = true;
                }
            }
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            if (this.flag)
            {
                this.BChar.BuffAdd("B_Sakuya_P_0", this.BChar, false, 0, false, -1, false);
                this.BChar.BuffAdd("B_Sakuya_P_0", this.BChar, false, 0, false, -1, false);
            }
        }

        public void checkLunaMagicEffect()
        {
            //回费
            if (this.BChar.BuffFind("B_Sakuya_12Rare"))
            {
                BattleTeam allyTeam = BattleSystem.instance.AllyTeam;
                int ap = allyTeam.AP;
                allyTeam.AP = ap + 1;
            }

            //抽卡
            if (this.BChar.BuffFind("B_Sakuya_5_new"))
            {
                BattleSystem.instance.AllyTeam.Draw();
            }

            //伤害
            if (this.BChar.BuffFind("B_Sakuya_4_new"))
            {
                Skill skill2 = Skill.TempSkill("S_Sakuya_4_new", this.BChar, this.BChar.MyTeam);
                skill2.isExcept = true;
                skill2.FreeUse = true;
                skill2.PlusHit = true;
                BattleTeam.SkillRandomUse(this.BChar, skill2, false, true, false);
            }
        }
    }
}