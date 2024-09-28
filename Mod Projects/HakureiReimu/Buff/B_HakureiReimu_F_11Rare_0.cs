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
namespace HakureiReimu
{
	/// <summary>
	/// 世界如此可爱
	/// 连续使用技能不会失去[符卡等级]。
	/// </summary>
    public class B_HakureiReimu_F_11Rare_0:Buff
    {
        public override void DestroyByTurn()
        {
            base.DestroyByTurn();
            if (this.BChar.BuffFind("B_HakureiReimu_F_P"))
            {
                this.BChar.BuffReturn("B_HakureiReimu_F_P").SelfDestroy();
            }
        }
    }
}