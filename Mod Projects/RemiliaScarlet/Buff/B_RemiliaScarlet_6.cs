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
	/// 饱足
	/// 蕾米莉亚从血肉中获得了满足。暂时无法提升最大生命值。
	/// </summary>
    public class B_RemiliaScarlet_6:Buff
    {
        public override string DescExtended()
        {
            return this.BuffData.Description.Replace("&user", base.Usestate_L.Info.Name);
        }
    }
}