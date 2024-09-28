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
	/// 博丽结界
	/// </summary>
    public class B_HakureiReimu_F_P_1:Buff, IP_Hit
    {
        public override void Init()
        {
            base.Init();
            this.PlusStat.DMGTaken = -25 * StackNum;
        }

        public void Hit(SkillParticle SP, int Dmg, bool Cri)
        {
            if (Dmg > 0)
            {
                this.SelfDestroy();
            }
        }
    }
}