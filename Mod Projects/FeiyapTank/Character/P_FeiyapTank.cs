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
using BasicMethods;
namespace FeiyapTank
{
    /// <summary>
    /// 剑圣·绯夜氏
    /// Passive:
    /// 受到伤害时，若自身有技能处于倒计时期间，本回合内攻击力提升那个伤害的值。
    /// </summary>
    public class P_FeiyapTank : Passive_Char, IP_PlayerTurn
    {
        public void Turn()
        {
            if (!this.BChar.BuffFind("B_FeiyapTank_P"))
            {
                this.BChar.BuffAdd("B_FeiyapTank_P", this.BChar);
            }
        }
    }
}