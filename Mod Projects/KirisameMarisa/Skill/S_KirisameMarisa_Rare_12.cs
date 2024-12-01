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
namespace KirisameMarisa
{
	/// <summary>
	/// 星符「Satellite Illusion」
	/// 抽取1个技能。
	/// <i><color=#696969>似乎能和其他稀有符卡共鸣，引发出更加独特的力量……</color></i>
	/// </summary>
    public class S_KirisameMarisa_Rare_12:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            BattleSystem.instance.AllyTeam.Draw();
        }
    }
}