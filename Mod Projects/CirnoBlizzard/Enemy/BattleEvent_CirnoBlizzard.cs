using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using GameDataEditor;
using UnityEngine;

namespace CirnoBlizzard
{
    public class BattleEvent_CirnoBlizzard : PassiveBase, IP_BattleEnd
    {
        public override void Init()
        {
            base.Init();
        }

        public BattleEvent_CirnoBlizzard()
        {
        }

        public void BattleEnd()
        {
            BattleEvent_CirnoBlizzard.Boss = null;
            BattleEvent_CirnoBlizzard.MainP = null;
        }

        public static BattleEnemy Boss;

        public static B_Boss_Cirno_P MainP;

        public static int FreezeAP;
    }
}