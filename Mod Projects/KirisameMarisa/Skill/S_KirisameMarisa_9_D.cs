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
	/// 危险本能
	/// </summary>
    public class S_KirisameMarisa_9_D:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);

            if (Targets[0].BuffFind("B_KirisameMarisa_9_2"))
            {
                Targets[0].BuffReturn("B_KirisameMarisa_9_2").SelfDestroy();
            }
        }
    }
}