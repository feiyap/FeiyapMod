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
namespace FeiyapBoss
{
	/// <summary>
	/// 保护体力极限
	/// 每个回合开始时，恢复「上个回合中，自己受到过的最高的单次伤害值」的体力。
	/// </summary>
    public class B_Feiyap_Boss_P_1:Buff, IP_PlayerTurn, IP_DamageTake
    {
        public int hprecord = 0;
        public static int hprecordlast = 0;

        public override void Init()
        {
            base.Init();
            hprecord = 0;
            hprecordlast = 0;
        }

        public void Turn()
        {
            this.BChar.Heal(this.BChar, hprecord, false, false, null);
            hprecordlast = hprecord;
            hprecord = 0;
        }

        public void DamageTake(BattleChar User, int Dmg, bool Cri, ref bool resist, bool NODEF = false, bool NOEFFECT = false, BattleChar Target = null)
        {
            if (Target == this.BChar)
            {
                if (Dmg >= hprecord)
                {
                    hprecord = Dmg;
                }
            }
        }

        public override string DescExtended()
        {
            return base.DescExtended().Replace("&a", hprecord.ToString())
                                      .Replace("&b", hprecordlast.ToString());
        }
    }
}