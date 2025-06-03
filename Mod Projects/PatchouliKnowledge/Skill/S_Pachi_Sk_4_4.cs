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
	/// 土符「慵懒三石塔」
	/// 生成 &a 防护墙(防御力的100%)。
	/// 每个等级的“土”使生成的防护墙提升 &a (防御力的20%)，额外施加 1 层“石至名归”。
	/// </summary>
    public class S_Pachi_Sk_4_4:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            this.BChar.MyTeam.partybarrier.BarrierHP += (int)((float)this.BChar.GetStat.def * (1.0f + BattleSystem.instance.GetBattleValue<BV_Pachi_P>().elementLevel[4] * 0.2f));

            //for (int i = 0; i < BattleSystem.instance.GetBattleValue<BV_Pachi_P>().elementLevel[4]; i++)
            //{
            //    foreach (BattleChar bc in Targets)
            //    {
            //        bc.BuffAdd("B_Pachi_4_4", this.BChar);
            //    }
            //}
        }

        public override string DescExtended(string desc)
        {
            if (BattleSystem.instance == null)
            {
                return base.DescExtended(desc).Replace("&a", (0).ToString())
                                          .Replace("&b", (0).ToString());
            }
            return base.DescExtended(desc).Replace("&a", ((int)(this.BChar.GetStat.def * 1.0f)).ToString())
                                          .Replace("&b", ((int)(this.BChar.GetStat.def * 0.2f)).ToString());
        }
    }
}