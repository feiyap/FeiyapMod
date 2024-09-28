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
namespace RemiliaScarlet
{
    /// <summary>
    /// 永幼之赤月
    /// 增加10%暴击率、命中率、闪避率。
    /// </summary>
    public class B_RemiliaScarlet_P:Buff
    {
        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
            this.PlusStat.cri = 10f;
            this.PlusStat.dod = 10f;
            this.PlusStat.hit = 10f;
        }
    }
}