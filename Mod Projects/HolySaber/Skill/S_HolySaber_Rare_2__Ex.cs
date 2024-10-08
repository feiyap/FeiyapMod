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
namespace HolySaber
{
	/// <summary>
	/// <color=#FFA500>神谕的启程·贞德</color>
	/// 使手中所有可<color=#FFA500>进化</color>的技能<color=#FFA500>进化</color>。
	/// </summary>
    public class S_HolySaber_Rare_2__Ex: SkillExtended_HolySaber
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);

            foreach (Skill skill in BattleSystem.instance.AllyTeam.Skills)
            {
                if (skill != MySkill && skill.ExtendedFind_DataName("SE_HolySaber_Extend") != null && skill.ExtendedFind_DataName("SE_HolySaber_Extended") == null)
                {
                    SkillChange(skill, true);
                }
            }
        }
    }
}