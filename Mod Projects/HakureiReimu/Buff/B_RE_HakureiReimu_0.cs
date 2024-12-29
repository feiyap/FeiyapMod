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
	/// 每回合抽牌
	/// 每回合抽取的技能数量+1。
	/// </summary>
    public class B_RE_HakureiReimu_0:Buff
    {
        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
            this.PlusStat.PlusDraw = 1;
        }

        public void BattleStartUIOnBefore(BattleSystem Ins)
        {
            this.PlusStat.PlusDraw = 1;
        }
    }
}