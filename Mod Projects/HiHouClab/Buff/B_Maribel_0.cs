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
namespace HiHouClab
{
	/// <summary>
	/// 结界的一滴
	/// 可无视嘲讽指定为目标。
	/// </summary>
    public class B_Maribel_0:Buff, IP_DamageTakeChange_Quantum
    {
        public int DamageTakeChange_Quantum(BattleChar Hit, BattleChar User, int Dmg, bool Cri, bool NODEF = false, bool NOEFFECT = false, bool Preview = false)
        {
            if (Hit == this.BChar)
            {
                Dmg = Dmg * 130 / 100;
            }
            return Dmg;
        }

        public override void Init()
        {
            base.Init();
            this.PlusStat.Weak = true;
            this.PlusStat.IgnoreTaunt_EnemySelf = true;
        }
    }
}