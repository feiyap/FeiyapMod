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
namespace Reisen
{
	/// <summary>
	/// 兔肉火锅
	/// 战斗结束后，超额治疗所有队员6点体力值。
	/// </summary>
    public class R_Reisen_0:PassiveItemBase, IP_BattleEnd
    {
        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
        }

        public void BattleEnd()
        {
            for (int i = 0; i < BattleSystem.instance.AllyList.Count; i++)
            {
                BattleSystem.instance.AllyList[i].Heal(BattleSystem.instance.AllyList[i], 6, false, true, null);
            }
        }
    }
}