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
namespace SatsukiRin
{
	/// <summary>
	/// 「那无法成为幻想的某物」
	/// 幻灭X - 获得X点防护墙。X为自身一半的[幻光]层数（向下取整）。
	/// </summary>
    public class S_Satsuki_11Rare:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);

            int num = 0;

            if (this.BChar.BuffFind("B_Satsuki_P", false))
            {
                num = this.BChar.BuffReturn("B_Satsuki_P", false).StackNum / 2;
            }

            for (int i = 0;i<num;i++)
            {
                this.BChar.BuffReturn("B_Satsuki_P", false).SelfStackDestroy();
            }
            Targets[0].MyTeam.partybarrier.BarrierHP += num;
        }

        public override string DescExtended(string desc)
        {
            if (this.BChar.BuffFind("B_Satsuki_P", false))
            {
                return base.DescExtended(desc).Replace("%a", ((int)(this.BChar.BuffReturn("B_Satsuki_P", false).StackNum / 2)).ToString());
            }
            else
            {
                return base.DescExtended(desc).Replace("%a", 0.ToString());
            }
        }
    }
}