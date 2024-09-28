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
namespace Lumiore
{
	/// <summary>
	/// 罗文的咆哮
	/// 使自己最大法力值+1。
	/// </summary>
    public class S_Lumiore_7_0:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            BattleSystem.instance.AllyTeam.LucyChar.BuffAdd("B_Lumiore_5", BattleSystem.instance.AllyTeam.LucyChar, false, 0, false, 1, false);
        }
    }
}