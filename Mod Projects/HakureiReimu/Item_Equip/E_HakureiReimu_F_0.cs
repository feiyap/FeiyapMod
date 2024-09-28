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
	/// 博丽符札
	/// 战斗开始时，使自身攻击力提升2点。
	/// </summary>
    public class E_HakureiReimu_F_0:EquipBase, IP_BattleStart_Ones
    {
        public override void Init()
        {
            base.Init();
            this.PlusStat.cri = 10;
        }

        public void BattleStart(BattleSystem Ins)
        {
            this.BChar.BuffAdd("B_HakureiReimu_F_E_0", this.BChar, false, 0, false, -1, false);
        }
    }
}