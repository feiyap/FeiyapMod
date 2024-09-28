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
namespace saber
{
	/// <summary>
	/// <color=#808080>风王结界</color>
	/// </summary>
    public class Saber_jiejie_B:Buff, IP_PlayerTurn, IP_Hit
    {
        public override void Init()
        {
            base.Init();
            this.PlusPerStat.Damage = (int)(float)(-50 * base.StackNum);
            this.PlusStat.cri = (float)(-50f * base.StackNum);
            this.PlusStat.PlusCriDmg = (int)(float)(-50f * base.StackNum);
            this.PlusStat.DMGTaken = (int)(float)(-30f * base.StackNum);
            this.PlusStat.dod = (int)(10 * base.StackNum);
            this.PlusStat.Strength = true;
            this.PlusStat.AggroPer = 80;
        }
        public void Turn()
        {
            this.BarrierHP += 8;
        }
        public void Hit(SkillParticle SP, int Dmg, bool Cri)
        {
            if (Dmg >= 1)
            {
                SP.UseStatus.BuffAdd(ModItemKeys.Buff_Saber_fengshi, base.Usestate_F, false, 0, false, -1, false);
            }
        }
    }
}