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
namespace Squall
{
	/// <summary>
	/// G.F.
	/// 丢弃目标技能，获得那个技能费用+1的[刃甲]层数。
	/// 那之后，优先抽取1个自己的技能。
	/// </summary>
    public class S_Squall_5:Skill_Extended
    {
        public override void SkillTargetSingle(List<Skill> Targets)
        {
            base.SkillTargetSingle(Targets);

            Targets[0].Delete();
            for (int i = 0; i < Targets[0].AP; i++)
            {
                this.BChar.BuffAdd("B_Squall_P", this.BChar);
            }

            BattleSystem.instance.AllyTeam.CharacterDraw(this.BChar, null);
        }
    }
}