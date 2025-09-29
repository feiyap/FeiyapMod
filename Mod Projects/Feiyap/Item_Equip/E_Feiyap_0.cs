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
namespace Feiyap
{
	/// <summary>
	/// 绯生一文字
	/// 保护体力极限。
	/// </summary>
    public class E_Feiyap_0:EquipBase
    {
        public override void Init()
        {
            base.Init();
            this.PlusStat.atk = 4;
            this.PlusStat.HIT_DOT = 40;
            this.PlusStat.Strength = true;
        }
    }
}