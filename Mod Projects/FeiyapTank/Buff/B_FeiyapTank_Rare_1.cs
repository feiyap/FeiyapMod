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
namespace FeiyapTank
{
    /// <summary>
    /// 紫雨
    /// 每次被施加痛苦减益时，触发一次该减益的伤害。
    /// </summary>
    public class B_FeiyapTank_Rare_1 : Buff, IP_BuffAdd
    {
        public void Buffadded(BattleChar BuffUser, BattleChar BuffTaker, Buff addedbuff)
        {
            if (BuffTaker == this.BChar && addedbuff.BuffData.BuffTag != null && addedbuff.BuffData.BuffTag.Key == GDEItemKeys.BuffTag_DOT && addedbuff.Tick() > 0)
            {
                this.BChar.Damage(this.Usestate_L, this.Tick(), false, true, true, 0, false, false, false);
            }
        }
    }
}