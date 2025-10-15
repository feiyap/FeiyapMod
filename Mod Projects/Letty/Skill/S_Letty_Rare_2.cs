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
	/// 「凛冬将至」
	/// </summary>
    public class S_Letty_Rare_2:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);
            List<BattleChar> list = new List<BattleChar>();
            list.AddRange(BattleSystem.instance.AllyTeam.AliveChars_Vanish);
            list.AddRange(BattleSystem.instance.EnemyTeam.AliveChars_Vanish);
            foreach (BattleChar battleChar in list.FindAll((BattleChar a) => a.BuffFind("B_Letty_P", false)))
            {
                battleChar.BuffReturn("B_Letty_P", false).BuffData.MaxStack = 4;
                if (battleChar.BuffReturn("B_Letty_P", false).StackNum >= 4)
                {
                    battleChar.BuffReturn("B_Letty_P", false).SelfDestroy();
                    battleChar.BuffAdd("B_Letty_P_1", this.BChar);
                }
            }
        }
    }
}