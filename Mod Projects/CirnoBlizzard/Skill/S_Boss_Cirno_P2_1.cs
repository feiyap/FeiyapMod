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
	/// 冰封魔印
	/// 召唤三个“冰封魔印”。
	/// </summary>
    public class S_Boss_Cirno_P2_1:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            BattleSystem.DelayInput(BattleSystem.instance.NewEnemyAutoPos("Enemy_Sigil", null));
            BattleSystem.DelayInput(BattleSystem.instance.NewEnemyAutoPos("Enemy_Sigil", null));
            BattleSystem.DelayInput(BattleSystem.instance.NewEnemyAutoPos("Enemy_Sigil", null));
        }
    }
}