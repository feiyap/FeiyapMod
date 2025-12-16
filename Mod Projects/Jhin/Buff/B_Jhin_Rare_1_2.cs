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
namespace Jhin
{
	/// <summary>
	/// 大美将至
	/// </summary>
    public class B_Jhin_Rare_1_2:Buff
    {
        public override void Init()
        {
            base.Init();
            this.PlusStat.cri = 44;
        }
    }
}