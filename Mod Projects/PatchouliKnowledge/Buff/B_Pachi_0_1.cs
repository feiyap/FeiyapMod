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
	/// 元素异常
	/// </summary>
    public class B_Pachi_0_1:Buff
    {
        public override void Init()
        {
            base.Init();
            this.PlusPerStat.Damage = -10 * StackNum;
            this.PlusStat.def = -10 * StackNum;
            this.PlusStat.hit = -10 * StackNum;
            this.PlusStat.cri = -10 * StackNum;
            this.PlusStat.dod = -10 * StackNum;
            this.PlusStat.RES_CC = 10 * StackNum;
            this.PlusStat.RES_DEBUFF = 10 * StackNum;
            this.PlusStat.RES_DOT = 10 * StackNum;
        }
    }
}