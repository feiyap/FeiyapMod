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
namespace Parsee
{
	/// <summary>
	/// 恨符「丑时参拜第七日」
	/// </summary>
    public class B_Parsee_Rare_1:Buff
    {
        public override void Init()
        {
            base.Init();
            this.PlusStat.DMGTaken = 100;
        }
    }
}