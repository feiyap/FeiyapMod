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
namespace Sunmeitian
{
	/// <summary>
	/// 西天取经
	/// 优先抽取2个自己的技能。
	/// </summary>
    public class S_Sunmeitian_7:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            for (int i = 0; i < 2; i++)
            {
                BattleSystem.instance.AllyTeam.CharacterDraw(this.BChar, null);
            }
        }
    }
}