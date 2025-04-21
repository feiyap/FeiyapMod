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
namespace szb_elena
{
	/// <summary>
	/// 耶拉的祈祷
	/// </summary>
    public class B_szb_elena_P:Buff,IP_ElenaHealed
    {
        public override void Init()
        {
            this.PlusStat.atk = P_szb_elena.HealedNum;
            this.PlusStat.reg = P_szb_elena.HealedNum;
            base.Init();
        }

        public void ElenaHealed() 
        {
            this.PlusStat.atk = P_szb_elena.HealedNum;
            this.PlusStat.maxhp = P_szb_elena.HealedNum;
        }

        public override void SelfdestroyPlus()
        {
            base.SelfdestroyPlus();
            this.BChar.BuffAdd(ModItemKeys.Buff_B_szb_elena_P, this.BChar, false, 0, false, -1, false);
        }
    }
}