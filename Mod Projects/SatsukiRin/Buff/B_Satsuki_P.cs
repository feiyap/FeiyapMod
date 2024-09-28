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
namespace SatsukiRin
{
	/// <summary>
	/// 幻光
	/// </summary>
    public class B_Satsuki_P:Buff
    {
        public override void Init()
        {
            base.Init();
            this.PlusStat.maxhp = 1 * StackNum;
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            this.PlusStat.maxhp = 1 * StackNum;
        }
    }
}