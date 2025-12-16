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

namespace Morichika
{
    /// <summary>
    /// </summary>
    public class B_Morichika_B_BuffEx : Buff_Ex
    {
        public override void BuffStat()
        {
            base.BuffStat();

            this.PlusStat.Strength = true;
        }
    }
}