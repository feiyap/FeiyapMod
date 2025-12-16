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
namespace CirnoBlizzard
{
	/// <summary>
	/// 污秽之心
	/// </summary>
    public class B_Boss_Cirno_P3_0_1:Buff, IP_TurnEnd, IP_Healed
    {
        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
        }

        public void TurnEnd()
        {
            this.BChar.HP = 0;
            this.BChar.Recovery = 1;
            BattleSystem.instance.AllyTeam.CharacterDraw(this.BChar);
        }

        public void Healed(BattleChar Healer, BattleChar HealedChar, int HealNum, bool Cri, int OverHeal)
        {
            if (Healer != HealedChar && HealedChar == this.BChar)
            {
                SelfDestroy();
                this.BChar.BuffAdd("B_Boss_Cirno_P3_0_3", this.BChar);
            }
        }
    }
}