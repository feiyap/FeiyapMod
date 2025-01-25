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
namespace RemiliaScarlet
{
    /// <summary>
    /// 魇月癫乱
    /// 使持有的所有减益的每回合伤害量提升33%。
    /// </summary>
    public class B_RemiliaScarlet_2_BuffEx : Buff_Ex
    {
        public override void BuffStat()
        {
            base.BuffStat();
            
            base.PlusDamageTick = (int)(((base.MainBuff.BuffData.Tick.DMG_Per * base.MainBuff.Usestate_L.GetStat.atk / 100) + base.MainBuff.BuffData.Tick.DMG_Base) * 0.33f * base.MainBuff.StackNum);
        }
    }
}