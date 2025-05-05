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
namespace VillageAlice
{
	/// <summary>
	/// 红王后
	/// 场上有目标受到混乱伤害时，对其追加释放“砍掉他的头”。
	/// </summary>
    public class B_FVAlice_Queen_P:Buff
    {
        public override void FixedUpdate()
        {
            base.FixedUpdate();
            foreach (BattleChar battleChar in this.BChar.BattleInfo.EnemyTeam.AliveChars)
            {
                if (!battleChar.BuffFind("B_FVAlice_Queen_P_0", false))
                {
                    battleChar.BuffAdd("B_FVAlice_Queen_P_0", this.BChar);
                }
            }
        }

        public override void SelfdestroyPlus()
        {
            foreach (BattleChar battleChar in this.BChar.BattleInfo.EnemyTeam.AliveChars)
            {
                battleChar.BuffRemove("B_FVAlice_Queen_P_0", false);
            }
            base.SelfdestroyPlus();
        }
    }
}