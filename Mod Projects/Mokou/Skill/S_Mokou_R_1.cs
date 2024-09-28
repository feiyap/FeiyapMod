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
using static System.Net.Mime.MediaTypeNames;
namespace Mokou
{
	/// <summary>
	/// 「这不知是第几次的生命，燃烧殆尽吧」
	/// </summary>
    public class S_Mokou_R_1:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            MasterAudio.PlaySound("Mokou_R1_1", 1f, null, 0f, null, null, false, false);
            base.SkillUseSingle(SkillD, Targets);
        }
    }
}