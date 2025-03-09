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
namespace HiHouClab
{
	/// <summary>
	/// 比普朗克更短的须臾
	/// 获得3点“普朗克法力值”。
	/// “普朗克法力值”能且仅能用于迅速技能的消耗。
	/// </summary>
    public class S_Renko_6:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);

            Planck.PlanckAP += 3;
        }
    }
}