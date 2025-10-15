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
namespace Necromancer
{
	/// <summary>
	/// 费用增加
	/// </summary>
    public class Extended_Necromancer_0_EX:Skill_Extended
    {
        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
            this.APChange = 1;
        }
    }
}