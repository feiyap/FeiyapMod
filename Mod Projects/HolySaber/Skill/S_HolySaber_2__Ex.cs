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
	/// <color=#FFA500>着魔的圣战士</color>
	/// 依据这个回合中从手中打出的拥有[守护]减益的技能数，抽取那个数量的技能。
	/// </summary>
    public class S_HolySaber_2__Ex: SkillExtended_HolySaber
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);

            int i = BattleSystem.instance.BattleLogs.getSkills((BattleLog log) => log.WhoUse.Info.Ally, (Skill skill) => !skill.FreeUse && skill.ExtendedFind_DataName("SE_HolySaber_Defend") != null, BattleSystem.instance.TurnNum).Count;
            BattleSystem.instance.AllyTeam.Draw(i);
        }
    }
}