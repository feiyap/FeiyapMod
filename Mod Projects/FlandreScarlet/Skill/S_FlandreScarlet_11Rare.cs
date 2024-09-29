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
namespace FlandreScarlet
{
	/// <summary>
	/// QED「495年的波纹」
	/// 当自己没有手牌时，将这个技能从牌库中抽取到手中。
	/// </summary>
    public class S_FlandreScarlet_11Rare:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            BattleSystem.instance.AllyTeam.CharacterDraw(this.BChar, null);
            BattleSystem.instance.AllyTeam.CharacterDraw(this.BChar, null);
        }
    }
}