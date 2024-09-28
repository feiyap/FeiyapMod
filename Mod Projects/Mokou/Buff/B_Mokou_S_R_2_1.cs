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
namespace Mokou
{
    /// <summary>
    /// 「涅槃重生」
    /// </summary>
    public class B_Mokou_S_R_2_1 : Buff
    {
        public override void BuffStat()
        {
            base.BuffStat();
            this.PlusStat.DMGTaken = -50f;
        }
    }
}