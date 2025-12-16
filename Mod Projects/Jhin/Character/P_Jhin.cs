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
namespace Jhin
{
	/// <summary>
	/// 烬
	/// Passive:
	/// 烬每个回合只能使用 4 个非稀有技能（包括固定能力），且技能的费用固定为1、2、3、4。如果该次技能暴击，则恢复0、1、2、3点法力值，并获得(14% + 额外命中率的44%)的闪避率，持续 1 回合。
	/// 第 4 个技能总是会产生暴击，并造成相当于目标已损失生命值的44%的额外伤害。
	/// </summary>
    public class P_Jhin:Passive_Char, IP_PlayerTurn
    {
        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
        }

        public void Turn()
        {
            if (BattleSystem.instance.GetBattleValue<BV_Jhin_P>() == null)
            {
                BattleSystem.instance.BattleValues.Add(new BV_Jhin_P());
            }

            if (!this.BChar.BuffFind("B_Jhin_P"))
            {
                this.BChar.BuffAdd("B_Jhin_P", this.BChar);
            }
        }
    }
}