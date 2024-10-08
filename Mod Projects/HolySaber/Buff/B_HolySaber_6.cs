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
namespace HolySaber
{
	/// <summary>
	/// 完美守护
	/// 受到攻击后解除。
	/// </summary>
    public class B_HolySaber_6:Buff, IP_Hit
    {
        public override void Init()
        {
            base.Init();
            this.PlusStat.PerfectShield = true;
        }
        
        public void Hit(SkillParticle SP, int Dmg, bool Cri)
        {
            if (Dmg >= 1)
            {
                base.SelfDestroy(false);
            }
        }
    }
}