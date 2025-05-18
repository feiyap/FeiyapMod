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
namespace Feiyap
{
	/// <summary>
	/// 孤燕之瞥
	/// 不会被施加任何来自其他单位的治疗效果。
	/// </summary>
    public class B_Feiyap_5:Buff, IP_HealChange
    {
        public override void Init()
        {
            base.Init();
            this.PlusPerStat.Damage = 20;
            this.PlusStat.DMGTaken = -20f;
            this.PlusStat.HEALTaken = 100f;
            this.PlusStat.DeadImmune = 40;
        }

        public void HealChange(BattleChar Healer, BattleChar HealedChar, ref int HealNum, bool Cri, ref bool Force)
        {
            if (Healer != this.BChar && HealedChar == this.BChar)
            {
                HealNum = 0;
            }
        }
    }
}