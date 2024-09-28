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
namespace Ralmia
{
	/// <summary>
	/// 突破音速
	/// 选择1张技能。使其获得迅速。
	/// </summary>
    public class S_Ralmia_P:Skill_Extended
    {
        public override void SkillTargetSingle(List<Skill> Targets)
        {
            Targets[0].NotCount = true;
        }
    }
}