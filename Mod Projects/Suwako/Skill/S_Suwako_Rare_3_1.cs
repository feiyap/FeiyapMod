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
using BasicMethods;
namespace Suwako
{
	/// <summary>
	/// 蛙符「涂有鲜血的赤蛙塚」
	/// 重复释放1次，然后抽取1个技能，并使这个技能获得1层[苏醒]。
	/// </summary>
    public class S_Suwako_Rare_3_1:Skill_Extended
    {
        public override bool ButtonSelectTerms()
        {
            return BattleSystem.instance.AllyTeam.Skills.FindAll((Skill i) => i.MySkill.KeyID != "S_Suwako_Rare_3").Count > 0;
        }
    }
}