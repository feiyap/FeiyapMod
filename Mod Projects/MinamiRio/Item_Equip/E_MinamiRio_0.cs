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
	/// 哲别之弓
	/// </summary>
    public class E_MinamiRio_0:EquipBase
    {
        public override void Init()
        {
            this.PlusStat.atk = 3;
            this.PlusStat.hit = 50;
        }
    }
}