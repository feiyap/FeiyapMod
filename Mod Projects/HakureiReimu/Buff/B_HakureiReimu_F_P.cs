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
namespace HakureiReimu
{
	/// <summary>
	/// 符卡等级
	/// </summary>
    public class B_HakureiReimu_F_P:Buff
    {
        public int Fixed_count = 0;

        public override void Init()
        {
            base.Init();
            this.PlusStat.hit = 2 * StackNum;
            this.PlusStat.dod = 2 * StackNum;
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            Fixed_count++;

            if (Fixed_count >= 12)
            {
                Fixed_count = 0;

                if (this.BChar.BuffFind("B_HakureiReimu_F_11Rare", false))
                {
                    this.PlusStat.hit = 0;
                    this.PlusStat.dod = 0;
                    this.PlusPerStat.Damage = 4 * StackNum;
                    this.PlusStat.def = 4 * StackNum;
                }
                else
                {
                    this.PlusStat.hit = 2 * StackNum;
                    this.PlusStat.dod = 2 * StackNum;
                    this.PlusPerStat.Damage = 0;
                    this.PlusStat.def = 0;
                }
            }
        }
    }
}