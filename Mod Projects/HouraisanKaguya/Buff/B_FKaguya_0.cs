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
namespace HouraisanKaguya
{
	/// <summary>
	/// 辉夜/龙玉
	/// </summary>
    public class B_FKaguya_0:Buff, IP_Hit
    {
        public int count;

        public override void Init()
        {
            base.Init();
            this.PlusStat.DMGTaken = 0;
        }

        public void Hit(SkillParticle SP, int Dmg, bool Cri)
        {
            if (SP.SkillData.PlusHit)
            {
                count++;
                this.PlusStat.DMGTaken = 5 * count;
            }
        }
    }
}