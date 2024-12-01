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
	/// 「这不知是第几次的生命，梦想封印吧」
	/// <color=#FFD700>*「梦想天生」+「这不知是第几次的生命，燃烧殆尽吧」*</color>
	/// 60%倍率。恢复1点法力值。
	/// </summary>
    public class S_Musoutensei_Mokou: SkillExtended_Reimu
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);

            MasterAudio.StopBus("BGM");
            MasterAudio.StopBus("BattleBGM");
            MasterAudio.PlaySound("Musoutensei_Mokou", 1f, null, 0f, null, null, false, false);
        }
    }
}