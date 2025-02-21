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
namespace Yuyuko
{
	/// <summary>
	/// 鬼影萦绕
	/// </summary>
    public class B_E_YuyukoF_1:Buff
    {
        public override void Init()
        {
            base.Init();
            this.PlusStat.atk = 2;
            this.PlusStat.Penetration = 50f;
        }
    }
}