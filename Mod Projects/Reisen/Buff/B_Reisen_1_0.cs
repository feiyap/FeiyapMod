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
namespace Reisen
{
	/// <summary>
	/// 幻象/懒冻
	/// 无法行动。
	/// </summary>
    public class B_Reisen_1_0:Buff
    {
        public override void Init()
        {
            base.Init();
            this.PlusStat.Stun = true;
            this.PlusStat.PerfectShield = true;
        }
        
        public override void BuffOneAwake()
        {
            base.BuffOneAwake();
            foreach (Buff buff in this.BChar.GetBuffs(BattleChar.GETBUFFTYPE.DOT, true, false))
            {
                buff.SelfDestroy(false);
            }
        }
    }
}