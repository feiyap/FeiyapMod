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
namespace HatsuneMiku
{
	/// <summary>
	/// 初音ミク
	/// Passive:
	/// 战斗开始时，为所有队友施加2层[未来之音]。
    ///
    /// 未来之音：回合结束时，恢复等量于层数的体力。那之后，消耗1层[未来之音]。
    ///
    /// 音弦X：初音未来的技能对拥有身上已有X层[未来之音] 的角色释放会触发额外效果。
    ///
    /// 音律X：初音未来身上有X层[未来之音] 时会触发额外效果。
	/// </summary>
    public class P_HatsuneMiku:Passive_Char, IP_BattleStart_Ones
    {
        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
        }

        public void BattleStart(BattleSystem Ins)
        {
            for (int i = 0; i < BattleSystem.instance.AllyList.Count; i++)
            {
                BattleSystem.instance.AllyList[i].BuffAdd("B_HatsuneMiku_P", this.BChar, false, 0, false, -1, false);
                BattleSystem.instance.AllyList[i].BuffAdd("B_HatsuneMiku_P", this.BChar, false, 0, false, -1, false);
            }
        }
    }
}