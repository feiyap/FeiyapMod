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
	/// 神之力量
	/// <color=#919191><i>向无冕之王致敬。</i></color>
	/// </summary>
    public class B_Feiyap_Rare_3:Buff
    {
        public override void Init()
        {
            base.Init();

        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();

            this.PlusPerStat.Damage = (this.BChar.GetStat.maxhp - this.BChar.HP) * 100 / this.BChar.GetStat.maxhp;
            if (this.PlusPerStat.Damage > 300)
            {
                this.PlusPerStat.Damage = 300;
            }
        }
    }
}