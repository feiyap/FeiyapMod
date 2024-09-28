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
namespace RemiliaScarlet
{
	/// <summary>
	/// 神术「吸血鬼幻想」
	/// 立刻获得10次交换次数。
	/// </summary>
    public class S_RemiliaScarlet_11Rare:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            this.BChar.MyTeam.DiscardCount += 10;
            BattleSystem.instance.AllyTeam.Draw(2);
        }
    }
}