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
namespace KochiyaSanae
{
	/// <summary>
	/// 暴击率+100%
	/// </summary>
    public class SE_Sanae_E_0:Skill_Extended
    {
        public override void Init()
        {
            base.Init();
            this.PlusSkillStat.cri = 100f;
        }
    }
}