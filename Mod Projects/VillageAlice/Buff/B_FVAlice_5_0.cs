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
namespace VillageAlice
{
	/// <summary>
	/// 沉没
	/// </summary>
    public class B_FVAlice_5_0:Buff
    {
        public override void Init()
        {
            base.Init();
            this.PlusStat.spd = -1;
        }

        public override void SelfdestroyPlus()
        {
            base.SelfdestroyPlus();
            this.BChar.BuffAdd("B_FVAlice_0", this.Usestate_F, false, 999);
            this.BChar.BuffAdd("B_FVAlice_1", this.Usestate_F, false, 999);
        }
    }
}