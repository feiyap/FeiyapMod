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
namespace KirisameMarisa
{
	/// <summary>
	/// 超绝偷感
	/// 受到超过5点的伤害时解除。
	/// </summary>
    public class B_KirisameMarisa_P_1:Buff, IP_Hit
    {
        public override void Init()
        {
            base.Init();
            this.PlusStat.cri = 100;
        }

        public void Hit(SkillParticle SP, int Dmg, bool Cri)
        {
            if (Dmg >= 5)
            {
                this.SelfDestroy();
            }
        }
    }
}