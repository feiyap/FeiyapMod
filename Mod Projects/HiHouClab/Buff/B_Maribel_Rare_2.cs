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
namespace HiHouClab
{
	/// <summary>
	/// 无敌
	/// </summary>
    public class B_Maribel_Rare_2:Buff
    {
        public override void Init()
        {
            base.Init();
            this.PlusStat.invincibility = true;
        }
    }
}