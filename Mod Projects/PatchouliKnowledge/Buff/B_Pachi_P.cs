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
using BasicMethods;
namespace PatchouliKnowledge
{
	/// <summary>
	/// 元素精华
	/// </summary>
    public class B_Pachi_P:Buff, IP_ElementLevelUp
    {
        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
        }

        public override string DescExtended()
        {
            return base.DescExtended().Replace("&a", (BattleSystem.instance.GetBattleValue<BV_Pachi_P>().elementLevel[0]).ToString())
                                      .Replace("&b", (BattleSystem.instance.GetBattleValue<BV_Pachi_P>().elementLevel[1]).ToString())
                                      .Replace("&c", (BattleSystem.instance.GetBattleValue<BV_Pachi_P>().elementLevel[2]).ToString())
                                      .Replace("&d", (BattleSystem.instance.GetBattleValue<BV_Pachi_P>().elementLevel[3]).ToString())
                                      .Replace("&e", (BattleSystem.instance.GetBattleValue<BV_Pachi_P>().elementLevel[4]).ToString())
                                      .Replace("&f", (BattleSystem.instance.GetBattleValue<BV_Pachi_P>().elementLevel[5]).ToString())
                                      .Replace("&g", (BattleSystem.instance.GetBattleValue<BV_Pachi_P>().elementLevel[6]).ToString());
        }

        public void ElementLevelUp(int count)
        {
            this.PlusStat.atk = BattleSystem.instance.GetBattleValue<BV_Pachi_P>().elementLevel[3] * 2;
            this.PlusStat.cri = BattleSystem.instance.GetBattleValue<BV_Pachi_P>().elementLevel[3] * 2;

            this.PlusStat.reg = BattleSystem.instance.GetBattleValue<BV_Pachi_P>().elementLevel[2] * 2;
            this.PlusStat.dod = BattleSystem.instance.GetBattleValue<BV_Pachi_P>().elementLevel[2] * 2;

            this.PlusStat.def = BattleSystem.instance.GetBattleValue<BV_Pachi_P>().elementLevel[4] * 4;

            this.PlusStat.HIT_DOT = BattleSystem.instance.GetBattleValue<BV_Pachi_P>().elementLevel[0] * 10;
            this.PlusStat.RES_DOT = BattleSystem.instance.GetBattleValue<BV_Pachi_P>().elementLevel[0] * 10;

            this.PlusStat.HIT_CC = BattleSystem.instance.GetBattleValue<BV_Pachi_P>().elementLevel[1] * 10;
            this.PlusStat.HIT_DEBUFF = BattleSystem.instance.GetBattleValue<BV_Pachi_P>().elementLevel[1] * 10;
            this.PlusStat.RES_CC = BattleSystem.instance.GetBattleValue<BV_Pachi_P>().elementLevel[1] * 10;
            this.PlusStat.RES_DEBUFF = BattleSystem.instance.GetBattleValue<BV_Pachi_P>().elementLevel[1] * 10;

            this.PlusStat.PlusDraw = BattleSystem.instance.GetBattleValue<BV_Pachi_P>().elementLevel[5] * 1;

            this.PlusStat.MPR = BattleSystem.instance.GetBattleValue<BV_Pachi_P>().elementLevel[6] * 1;
        }
    }
}