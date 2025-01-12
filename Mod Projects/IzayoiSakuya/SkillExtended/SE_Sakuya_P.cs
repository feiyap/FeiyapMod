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
namespace IzayoiSakuya
{
	/// <summary>
	/// 月魔术
	/// </summary>
    public class SE_Sakuya_P: SkillExtended_Sakuya
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            if (CheckLunaMagic())
            {
                checkLunaMagicEffect();
            }
        }

        public void checkLunaMagicEffect()
        {

        }
    }
}