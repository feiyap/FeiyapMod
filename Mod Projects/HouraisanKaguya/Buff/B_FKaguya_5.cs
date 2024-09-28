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
	/// 辉夜/火蜥蜴
	/// 受到痛苦伤害翻倍；受到非痛苦伤害减半。
	/// </summary>
    public class B_FKaguya_5:Buff, IP_DamageTakeChange
    {
        public override void Init()
        {
            base.Init();
            this.PlusStat.Strength = true;
        }

        public int DamageTakeChange(BattleChar Hit, BattleChar User, int Dmg, bool Cri, bool NODEF = false, bool NOEFFECT = false, bool Preview = false)
        {
            if (NODEF)
            {
                Dmg *= 2;
            }
            else
            {
                Dmg /= 2;
            }
            return Dmg;
        }
    }
}