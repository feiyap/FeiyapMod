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
namespace HakureiReimu
{
	/// <summary>
	/// 绯狱「绯生一文字」
	/// <color=#FFD700>*「梦想天生」+禁忌「莱瓦汀」*</color>
	/// </summary>
    public class S_Musoutensei_Flandre: SkillExtended_Reimu
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);

            MasterAudio.StopBus("BGM");
            MasterAudio.StopBus("BattleBGM");
            MasterAudio.PlaySound("Musoutensei_Flandre", 1f, null, 0f, null, null, false, false);
        }
    }
}