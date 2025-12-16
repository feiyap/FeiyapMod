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
namespace CirnoBlizzard
{
	/// <summary>
	/// 完美冻结
	/// 无法行动。
	/// 受到攻击后解除。
	/// </summary>
    public class B_Boss_Cirno_Freeze:Buff, IP_Hit
    {
        public override void Init()
        {
            base.Init();
            this.PlusStat.Stun = true;
            this.PlusStat.PerfectShield = true;
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