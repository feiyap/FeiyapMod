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
namespace FFAce
{
	/// <summary>
	/// 苍蓝之冰
	/// </summary>
    public class S_FFAce_5_Ex:Skill_Extended
    {
        public override void FixedUpdate()
        {
            if (this.BChar.BuffFind("B_FFAce_Rare_2"))
            {
                this.APChange = -1;
            }
        }
    }
}