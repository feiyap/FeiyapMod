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
	/// 未来之音
	/// 回合结束时，恢复等量于层数的体力。
	/// 那之后，消耗1层[未来之音]。
	/// </summary>
    public class B_HatsuneMiku_P:Buff, IP_TurnEnd
    {
        public void TurnEnd()
        {
            this.BChar.Heal(this.BChar, this.StackNum, false, false, null);
            base.SelfStackDestroy();
        }
    }
}