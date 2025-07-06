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
namespace FairyLancelot
{
	/// <summary>
	/// 暴击率提升
	/// </summary>
    public class B_FLancelot_5_1:Buff
    {
        public override void Init()
        {
            base.Init();
            this.PlusStat.cri = 20;
        }
    }
}