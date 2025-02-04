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
namespace Yuyuko
{
	/// <summary>
	/// <color=#8B008B>亡乡「亡我乡 -无道之路-」</color>
	/// 放逐目标技能，并依据放逐技能的费用，每点费用减少50返魂值。
	/// </summary>
    public class S_YuyukoF_P_3:Skill_Extended
    {
        public override void SkillTargetSingle(List<Skill> Targets)
        {
            base.SkillTargetSingle(Targets);

            Targets[0].Except();
            BattleSystem.instance.GetBattleValue<BV_YuyukoF_P>().setFanhun(-50 * Targets[0].AP);
        }
    }
}