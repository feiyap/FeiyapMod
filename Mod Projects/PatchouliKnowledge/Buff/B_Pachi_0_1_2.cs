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
namespace PatchouliKnowledge
{
	/// <summary>
	/// 元素纠缠
	/// 结算时，自身每有 1 层痛苦减益，使这个减益增加 1 点每回合伤害。
	/// </summary>
    public class B_Pachi_0_1_2:Buff
    {
        public override void TurnUpdate()
        {
            base.TurnUpdate();

            List<Buff> buffs = this.BChar.GetBuffs(BattleChar.GETBUFFTYPE.DOT, false, false);
            int num = 0;
            foreach (Buff buff in buffs)
            {
                num += buff.StackNum;
            }

            if (num > 0)
            {
                this.PlusDamageTick += num;
            }
        }
    }
}