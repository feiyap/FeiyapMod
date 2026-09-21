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

namespace YakumoYukari
{
    /// <summary>
    /// 幻想的境界
    /// 显示迅捷/移动/标准剩余与境界力。
    /// </summary>
    public class B_YakumoYukari_P : Buff
    {
        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
        }

        public override string DescExtended()
        {
            BV_YakumoYukari_P bv = BV_YakumoYukari_P.Get();
            if (bv == null)
            {
                return base.DescExtended();
            }
            return base.DescExtended()
                .Replace("&a", bv.Swift.ToString())
                .Replace("&b", bv.Move.ToString())
                .Replace("&c", bv.Standard.ToString())
                .Replace("&d", bv.Boundary.ToString())
                .Replace("&e", bv.MaxBoundary(this.BChar).ToString());
        }
    }
}
