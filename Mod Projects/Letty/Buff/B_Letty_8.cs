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
namespace Letty
{
	/// <summary>
	/// 新雪
	/// 受到伤害量降低 &a(&user的防御力的100%)。
	/// </summary>
    public class B_Letty_8:Buff
    {
        public override void Init()
        {
            base.Init();
            this.PlusStat.DMGTaken = 0;
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            this.PlusStat.DMGTaken = -this.Usestate_L.GetStat.def;
        }

        public override string DescExtended()
        {

            return base.DescExtended().Replace("&a", (this.Usestate_L.GetStat.def).ToString())
                                      .Replace("&user", this.Usestate_L.Info.Name);
        }
    }
}