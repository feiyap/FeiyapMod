using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using GameDataEditor;
using UnityEngine;

namespace FeiyapTank
{
    public class BattleEvent_FeiyapMage : PassiveBase, IP_BattleEnd
    {
        public override void Init()
        {
            base.Init();

            SuperHand = 0;
        }

        public BattleEvent_FeiyapMage()
        {
        }

        public void BattleEnd()
        {
            BattleEvent_FeiyapMage.Boss = null;
            BattleEvent_FeiyapMage.MainP = null;
        }

        public static BattleChar Boss;

        public static B_Boss_FeiyapMage_P MainP;

        public static int SuperHand;
    }
}