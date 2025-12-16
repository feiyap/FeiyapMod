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
namespace CirnoBlizzard
{
	/// <summary>
	/// 深冬
	/// 攻击目标以外的所有调查员。
	/// </summary>
    public class S_Boss_Cirno_P3_5:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            List<BattleChar> result = BattleSystem.instance.AllyList.Except(Targets).ToList();

            Targets.Clear();
            Targets = result;
        }
    }
}