using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using GameDataEditor;
using UnityEngine;

namespace HinanawiTenshi
{
    public class BattleEvent_Tenshi : PassiveBase, IP_BattleEnd
    {
        public override void Init()
        {
            base.Init();
        }

        public BattleEvent_Tenshi()
        {
        }

        public void BattleEnd()
        {
            BattleEvent_Tenshi.Boss = null;
            BattleEvent_Tenshi.MainP = null;
        }

        public static BattleChar Boss;

        public static Boss_B_Tenshi_P MainP;
    }
}