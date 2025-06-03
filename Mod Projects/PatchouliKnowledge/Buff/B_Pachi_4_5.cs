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
	/// 戴森球
	/// 永久有效
	/// 到达 5 层时，额外提升100%暴击率。
	/// </summary>
    public class B_Pachi_4_5:Buff
    {
        public override void Init()
        {
            base.Init();
            this.PlusStat.atk = StackNum;
            this.PlusStat.def = 4 * StackNum;
            if (StackNum >= 5)
            {
                this.PlusStat.cri = 100;
            }
        }
    }
}