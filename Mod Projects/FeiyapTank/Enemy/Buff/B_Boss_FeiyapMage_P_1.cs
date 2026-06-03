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
	/// 百巧手
	/// 当前层数：&a
	/// </summary>
    public class B_Boss_FeiyapMage_P_1:Buff
    {
        public override void FixedUpdate()
        {
            base.FixedUpdate();

            this.PlusStat.atk = BattleEvent_FeiyapMage.SuperHand;
            this.PlusStat.reg = BattleEvent_FeiyapMage.SuperHand;
        }

        public override string DescExtended()
        {
            return this.BuffData.Description.Replace("&a", ((int)(BattleEvent_FeiyapMage.SuperHand)).ToString());
        }
    }
}