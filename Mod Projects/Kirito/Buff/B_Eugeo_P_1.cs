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
namespace Kirito
{
	/// <summary>
	/// 血色蔷薇之剑
	/// 攻击力+40%。每次攻击恢复100%攻击力体力。
	/// </summary>
    public class B_Eugeo_P_1:Buff, IP_DealDamage
    {
        public override void Init()
        {
            base.Init();
            this.PlusStat.atk = 40f;
        }

        public void DealDamage(BattleChar Take, int Damage, bool IsCri, bool IsDot)
        {
            if (Damage >= 1)
            {
                this.BChar.Heal(this.BChar, (float)((int)((float)this.BChar.GetStat.atk * 1.0f)), false, false, null);
            }
        }
    }
}