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
namespace Reisen
{
	/// <summary>
	/// 幻象/赤月
	/// </summary>
    public class B_Reisen_P:Buff
    {
        public override void Init()
        {
            base.Init();
            this.PlusPerStat.Damage = 10;
            this.PlusStat.DMGTaken = 20;
        }

        public override string DescExtended()
        {
            return base.DescExtended().Replace("&a", ((int)(this.BChar.GetStat.atk * 0.3)).ToString());
        }
    }
}