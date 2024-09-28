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
namespace saber
{
    public class Saber_bihu_ex : Skill_Extended
    {
        public override void FixedUpdate()
        {
            bool flag = this.BChar.BuffFind("Saber_moli", false);
            if (flag)
            {
                int num = this.BChar.BuffReturn("Saber_moli", false).StackNum;               
                this.APChange = -num;
            }
        }
        public override string DescExtended(string desc)
        {
            return base.DescExtended(desc).Replace("&a", ((int)Misc.PerToNum((float)this.BChar.GetStat.maxhp, 25f)).ToString()).Replace("&b", ((int)Misc.PerToNum((float)this.BChar.GetStat.maxhp, 50f)).ToString());
        }
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            
            base.SkillUseSingle(SkillD, Targets);
            foreach (BattleChar battleChar in BattleSystem.instance.AllyList)
            {
                bool flag = battleChar.BuffFind("SaberBuff", false);
                if (flag)
                {
                    Targets[0].Damage(Targets[0], (int)Misc.PerToNum((float)Targets[0].GetStat.maxhp, 25f), false, true, false, 0, false, false, false);
                }
                bool flag2 = !battleChar.BuffFind("SaberBuff", false);
                if (flag2)
                {
                    battleChar.BuffAdd("Saber_bihu_hudun", this.BChar, false, 0, false, -1, false);
                }
            }
            bool flag3 = this.BChar.BuffFind("Saber_moli", false)&& this.BChar.BuffReturn("Saber_moli", false).StackNum < 4;
            if (flag3)
            {
                int num = this.BChar.BuffReturn("Saber_moli", false).StackNum;
                BattleSystem.instance.AllyTeam.AP++;
                Ex_Saber_jiefang.Usemoli(num, this.BChar);
            }
            else 
            {
                BattleSystem.instance.AllyTeam.AP++;
                Ex_Saber_jiefang.Usemoli(3, this.BChar);
            }
        }
    }
}