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
namespace FairyLancelot
{
	/// <summary>
	/// 幻想种
	/// </summary>
    public class B_FLancelot_Rare_2:Buff, IP_DealDamage
    {
        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
        }

        public void DealDamage(BattleChar Take, int Damage, bool IsCri, bool IsDot)
        {
            if (Damage > 0 && !Take.Info.Ally)
            {
                this.BChar.Damage(this.BChar, 10, false, true);
                this.BChar.BuffAdd("B_FLancelot_Rare_2_0", this.BChar);
            }
        }
    }
}