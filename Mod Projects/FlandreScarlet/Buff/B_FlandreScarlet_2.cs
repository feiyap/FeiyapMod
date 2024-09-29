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
namespace FlandreScarlet
{
	/// <summary>
	/// 红莓陷阱
	/// 芙兰朵露每次对其造成伤害时，超额治疗自己1点体力。
	/// </summary>
    public class B_FlandreScarlet_2:Buff, IP_DamageTake
    {
        public override string DescExtended()
        {
            return base.DescExtended().Replace("&a", base.Usestate_F.Info.Name);
        }

        public void DamageTake(BattleChar User, int Dmg, bool Cri, ref bool resist, bool NODEF = false, bool NOEFFECT = false, BattleChar Target = null)
        {
            if (User == base.Usestate_F)
            {
                User.Heal(this.BChar, 1, this.BChar.GetCri(), true, null);
            }
        }

        public override void Init()
        {
            base.Init();
            this.PlusStat.def = -10f;
        }
    }
}