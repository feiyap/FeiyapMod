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
	/// 死欲蝶
	/// </summary>
    public class B_YuyukoF_5:Buff
    {
        public override void Init()
        {
            base.Init();
            this.PlusStat.crihit = 25;
            this.PlusStat.CRIGetDMG = 25;
        }
    }
}