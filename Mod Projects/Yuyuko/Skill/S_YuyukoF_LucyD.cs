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
	/// 寿命「通向无寿国的期票」
	/// 放逐目标技能，抽取3个技能。
	/// </summary>
    public class S_YuyukoF_LucyD:Skill_Extended
    {
        public override void SkillTargetSingle(List<Skill> Targets)
        {
            base.SkillTargetSingle(Targets);

            Targets[0].Except();
            BattleSystem.instance.AllyTeam.Draw(3);
        }
    }
}