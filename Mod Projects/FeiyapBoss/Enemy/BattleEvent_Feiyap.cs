using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using GameDataEditor;
using UnityEngine;

namespace FeiyapBoss
{
    public class BattleEvent_Feiyap : PassiveBase, IP_BattleEnd
    {
        public override void Init()
        {
            base.Init();
        }

        public BattleEvent_Feiyap()
        {
        }

        public void BattleEnd()
        {
            BattleEvent_Feiyap.Boss = null;
            BattleEvent_Feiyap.MainP = null;
        }

        public static BattleChar Boss;

        public static B_Feiyap_Boss_P MainP;
    }
}