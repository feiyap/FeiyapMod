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
namespace PatchouliKnowledge
{
	/// <summary>
	/// 登月计划
	/// </summary>
    public class B_Pachi_4_6:Buff
    {
        public override void Init()
        {
            base.Init();
            this.PlusStat.Strength = true;
            this.PlusPerStat.MaxHP = 70;
        }
    }
}