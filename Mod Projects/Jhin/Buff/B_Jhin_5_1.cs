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
namespace Jhin
{
	/// <summary>
	/// 一板一眼
	/// 自身超过100%的暴击率转化为暴击伤害。
	/// </summary>
    public class B_Jhin_5_1:Buff
    {
        public override void Init()
        {
            base.Init();
            this.PlusStat.cri = 44;
            this.PlusStat.PlusCriDmg = 44;
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            this.PlusStat.PlusCriDmg = 44 + ((this.BChar.GetStat.cri > 100) ? (this.BChar.GetStat.cri - 100) : 0);
        }
    }
}