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
namespace YasakaKanano
{
	/// <summary>
	/// 神符「结于杉木之古缘」
	/// </summary>
    public class S_Kanano_Rare_3_2:Skill_Extended
    {
        public override bool ButtonSelectTerms()
        {
            return BattleSystem.instance.GetBattleValue<BV_Kanano_Rare_3>().UseNum2 == 0;
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            BattleSystem.instance.GetBattleValue<BV_Kanano_Rare_3>().UseNum2++;
        }
    }
}