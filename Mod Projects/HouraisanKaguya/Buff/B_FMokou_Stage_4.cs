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
namespace HouraisanKaguya
{
    /// <summary>
    /// 虚人「无」
    /// </summary>
    public class B_FMokou_Stage_4 : Buff, IP_DamageTake, IP_TurnEnd
    {
        public int count;

        public override void Init()
        {
            this.BChar.Info.PlusActCount.Add(1);
            this.BChar.Info.PlusActCount.Add(1);
            base.Init();
            count = 0;
        }

        public void DamageTake(BattleChar User, int Dmg, bool Cri, ref bool resist, bool NODEF = false, bool NOEFFECT = false, BattleChar Target = null)
        {
            resist = true;
        }

        public void TurnEnd()
        {
            count++;
            if (count >= 3)
            {
                this.BChar.Dead();
            }
        }
    }
}