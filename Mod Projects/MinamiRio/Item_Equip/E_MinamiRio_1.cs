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
namespace MinamiRio
{
	/// <summary>
	/// 血之刻印
	/// </summary>
    public class E_MinamiRio_1:EquipBase
    {
        public override void Init()
        {
            this.PlusStat.atk = 4;
            this.PlusStat.cri = 15;
            this.PlusStat.hit = 100;
            this.PlusStat.HitMaximum = true;
        }
    }
}