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
namespace FairyLancelot
{
	/// <summary>
	/// 妖精湖的加护
	/// 根据当前回合数，提升2倍的防御力、最大体力值和10倍的减益成功率。
	/// </summary>
    public class B_FLancelot_6:Buff
    {
        public override void Init()
        {
            base.Init();
            this.PlusStat.def = 2 * BattleSystem.instance?.TurnNum ?? 0;
            this.PlusStat.maxhp = 2 * BattleSystem.instance?.TurnNum ?? 0;
            this.PlusStat.HIT_CC = 10 * BattleSystem.instance?.TurnNum ?? 0;
            this.PlusStat.HIT_DEBUFF = 10 * BattleSystem.instance?.TurnNum ?? 0;
            this.PlusStat.HIT_DOT = 10 * BattleSystem.instance?.TurnNum ?? 0;
        }
    }
}