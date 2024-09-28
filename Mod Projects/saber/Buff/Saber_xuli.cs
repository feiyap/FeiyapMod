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
namespace saber
{
    public class Saber_xuli: Buff
    {
        public override void Init()
        {
            this.PlusStat.DMGTaken= -50f;
            base.Init();
            this.PlusStat.Stun = true;
        }
    }
}