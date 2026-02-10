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
    /// 红血
    /// </summary>
    public class B_FeiyapTank_4_2 : Buff, IP_DamageTake
    {
        public void DamageTake(BattleChar User, int Dmg, bool Cri, ref bool resist, bool NODEF = false, bool NOEFFECT = false, BattleChar Target = null)
        {
            if (Target == this.BChar)
            {
                foreach (BattleChar bc in BattleSystem.instance.EnemyList)
                {
                    if (bc.BuffFind("B_FeiyapTank_4", this.BChar))
                    {
                        bc.Damage(this.BChar, Dmg, Cri, true);
                    }
                }
            }
        }
    }
}