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
namespace Inaba
{
	/// <summary>
	/// 因幡/逃逸
	/// 受到伤害时，转移给拥有[因幡/误导]的单位；
	/// 解除时优先抽取1个自己的技能。
	/// </summary>
    public class B_Inaba_7:Buff, IP_DamageTake, IP_PlayerTurn
    {
        public void DamageTake(BattleChar User, int Dmg, bool Cri, ref bool resist, bool NODEF = false, bool NOEFFECT = false, BattleChar Target = null)
        {
            if (Dmg >= 1 && !resist)
            {
                foreach (BattleAlly battleAlly in BattleSystem.instance.AllyList)
                {
                    if (battleAlly.BuffFind("B_Inaba_7_0"))
                    {
                        resist = true;
                        battleAlly.Damage(User, Dmg, Cri, true);
                    }
                }
            }
        }

        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
        }

        public void Turn()
        {
            BattleSystem.instance.AllyTeam.CharacterDraw(this.BChar, null);

            this.SelfDestroy();
        }
    }
}