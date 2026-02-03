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
    /// 复制体
    ///  被创造出来的复制体。受到的伤害将由本体代为承担。
    /// </summary>
    public class B_Renko_Rare_2_0 : Buff, IP_DamageTakeChange
    {
        public int DamageTakeChange(BattleChar Hit, BattleChar User, int Dmg, bool Cri, bool NODEF = false, bool NOEFFECT = false, bool Preview = false)
        {
            if (Preview)
            {
                return Dmg;
            }

            foreach (var bc in BattleSystem.instance.EnemyList)
            {
                if (bc != User && bc.BuffFind("B_Renko_Rare_2"))
                {
                    bc.Damage(User, Dmg, Cri);
                }
            }

            Dmg = 0;

            return Dmg;
        }

        //public int DamageTakeChange_Quantum(BattleChar Hit, BattleChar User, int Dmg, bool Cri, bool NODEF = false, bool NOEFFECT = false, bool Preview = false)
        //{
        //    Dmg = 0;
        //    return Dmg;
        //}

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            if (!BattleSystem.instance.EnemyList.Any((BattleEnemy be) => be.BuffFind("B_Renko_Rare_2")))
            {
                this.BChar.Dead();
            }
        }
    }
}