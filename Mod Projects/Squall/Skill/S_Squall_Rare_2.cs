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
	/// 狮子之心
	/// 计算握在手中后获得的刃甲层数（最高10），当前获得的刃甲层数：&a
	/// </summary>
    public class S_Squall_Rare_2:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);
            List<BattleChar> list = new List<BattleChar>();
            list.AddRange(BattleSystem.instance.AllyTeam.AliveChars_Vanish);
            list.AddRange(BattleSystem.instance.EnemyTeam.AliveChars_Vanish);
            foreach (BattleChar battleChar in list.FindAll((BattleChar a) => a.BuffFind("B_Squall_P", false)))
            {
                battleChar.BuffReturn("B_Squall_P", false).BuffData.MaxStack = 15;
            }
        }
    }
}