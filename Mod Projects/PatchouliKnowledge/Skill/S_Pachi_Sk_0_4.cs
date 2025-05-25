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
namespace PatchouliKnowledge
{
	/// <summary>
	/// 土金符「翡翠巨石」
	/// 施加 &a 点保护罩(防御力的50%)。
	/// 每个等级的“金”额外施加1层“巨石护卫”。
	/// 每个等级的“土”额外施加&b点保护罩(防御力的10%)。
	/// </summary>
    public class S_Pachi_Sk_0_4:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            int num = (int)this.BChar.GetStat.def * (int)(0.5 + BattleSystem.instance.GetBattleValue<BV_Pachi_P>().elementLevel[4] * 0.1);
            
            foreach (BattleChar bc in Targets)
            {
                bc.BuffAdd("B_Pachi_Barrier", this.BChar).BarrierHP += num;
            }

            for (int i = 0; i < BattleSystem.instance.GetBattleValue<BV_Pachi_P>().elementLevel[0]; i++)
            {
                foreach (BattleChar bc in Targets)
                {
                    bc.BuffAdd("B_Pachi_0_4", this.BChar);
                }
            }
        }

        public override string DescExtended(string desc)
        {
            return base.DescExtended(desc).Replace("&a", ((int)(this.BChar.GetStat.def * 0.5f)).ToString())
                                          .Replace("&b", ((int)(this.BChar.GetStat.def * 0.1f)).ToString());
        }
    }
}