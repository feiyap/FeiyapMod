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

namespace VillageAlice
{
    public class B_FVAlice_2_BuffEx : Buff_Ex
    {
        public override void BuffStat()
        {
            base.BuffStat();

            if (base.MainBuff.Usestate_L == null)
            {
                return;
            }
            
            //base.PlusDamageTick = (int)((base.MainBuff.Usestate_L.GetStat.atk * 30 / 100) + 1);
        }

        public override void TurnUpdate()
        {
            this.BChar.ChaosDamage(this.BChar, (int)((base.MainBuff.Usestate_L.GetStat.atk * 30 / 100) + 1), false);
        }
    }
}
