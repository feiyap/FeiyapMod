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
namespace YorigamiSister
{
    /// <summary>
    /// 夏季促销
    /// 受到的伤害转化为等量的金币。这个减益的效果只在黑雾回合到来前有效。
    /// </summary>
    public class B_Joon_7:Buff, IP_DamageTake
    {
        public void DamageTake(BattleChar User, int Dmg, bool Cri, ref bool resist, bool NODEF = false, bool NOEFFECT = false, BattleChar Target = null)
        {
            if (Target == this.BChar && BattleSystem.instance.TurnNum <= BattleSystem.instance.FogTurn)
            {
                PlayData.Gold += Dmg;
            }
        }
    }
}