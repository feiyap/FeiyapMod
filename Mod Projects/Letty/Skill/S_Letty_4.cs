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
namespace Letty
{
	/// <summary>
	/// 冬符「花之凋零」
	/// 若目标持有弱化减益，施加“冻僵”。
	/// 若目标持有干扰减益，则使自身获得“雪花”。
	/// </summary>
    public class S_Letty_4:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            if (Targets[0].GetBuffs(BattleChar.GETBUFFTYPE.DEBUFF, false, false).Count >= 1)
            {
                Targets[0].BuffAdd("B_Letty_P_1", this.BChar);
            }

            if (Targets[0].GetBuffs(BattleChar.GETBUFFTYPE.CC, false, false).Count >= 1)
            {
                this.BChar.BuffAdd("B_Letty_0", this.BChar);
            }
        }
    }
}