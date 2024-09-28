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
namespace Mokou
{
	/// <summary>
	/// 「蓬莱人形」
	/// 对自身施加赤魂+1层数的烧伤，连锁治疗其他友方自身（赤魂层数）*20%的最大体力值
	/// </summary>
    public class S_Mokou_5:Skill_Extended
    {
        public override string DescExtended(string desc)
        {
            return base.DescExtended(desc).Replace("&a", num.ToString()).Replace("&b", (num * 16).ToString()).
                Replace("&c", ((int)(num * (int)Misc.PerToNum((float)this.BChar.GetStat.maxhp, 16f))).ToString());
        }
        public override void Init()
        {
            base.Init();
            this.SkillParticleObject = new GDESkillExtendedData(GDEItemKeys.SkillExtended_MissChain_Ex_P).Particle_Path;
        }
        public override void FixedUpdate()
        {
            if (this.BChar.BuffReturn("B_Mokou_0", false) == null)
            {
                num = 1;
            }
            else
            {
                num = this.BChar.BuffReturn("B_Mokou_0", false).StackNum + 1;
            }
            base.FixedUpdate();
            if (EX_ability.CheckEXburn(3, this.BChar))
            {
                base.SkillParticleOn();
            }
            else
            {
                base.SkillParticleOff();
            }
        }
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            if (EX_ability.CheckEXburn(3, this.BChar))
            {
                foreach (BattleChar battleChar in BattleSystem.instance.AllyTeam.AliveChars)
                {
                    if(battleChar != this.BChar)
                    {
                        battleChar.BuffAdd("B_Mokou_S_5_0", this.BChar, false, 0, false, -1, false);
                    }
                }
                num2 = 1;
            }
            for (int i = 0; i < num; i++)
            {
                this.BChar.BuffAdd("B_Mokou_T_1", this.BChar, false, 0, false, -1, false);
            }
            int num1 = (int)Misc.PerToNum((float)this.BChar.GetStat.maxhp, (float)(num) * 16);
            this.BChar.Heal(this.BChar, (float)num1, false, false, new BattleChar.ChineHeal());
            if (num2 == 1)
            {
                EX_ability.UseEXburn(3, this.BChar);
            }
        }
        public int num = 0;
        public int num2 = 0;
    }
}