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
namespace HatsuneMiku
{
	/// <summary>
	/// 太陽系デスコ
	/// 攻击时增加自己身上[未来之音]层数的伤害。
	/// </summary>
    public class B_HatsuneMiku_7:Buff
    {
        public override void Init()
        {
            base.Init();
            if (this.BChar.BuffFind("B_HatsuneMiku_P"))
            {
                this.PlusStat.atk = this.BChar.BuffReturn("B_HatsuneMiku_P", false).StackNum;
            }
            else
            {
                this.PlusStat.atk = 0;
            }
        }

        public override void FixedUpdate()
        {
            if (this.BChar.BuffFind("B_HatsuneMiku_P"))
            {
                this.PlusStat.atk = this.BChar.BuffReturn("B_HatsuneMiku_P", false).StackNum;
            }
            else
            {
                this.PlusStat.atk = 0;
            }
        }
    }
}