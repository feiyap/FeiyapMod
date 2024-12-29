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
	/// 赤色杀人魔！
	/// 受到治疗后，下一次出手的技能的伤害增加10%。
	/// </summary>
    public class B_Musoutensei_Daiyousei_1:Buff, IP_Healed
    {
        public void Healed(BattleChar Healer, BattleChar HealedChar, int HealNum, bool Cri, int OverHeal)
        {
            if (HealedChar == this.BChar)
            {
                this.BChar.BuffAdd("B_Musoutensei_Daiyousei_2", this.BChar, false, 0, false, -1, false);
            }
        }
    }
}