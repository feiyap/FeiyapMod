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
namespace Reisen
{
	/// <summary>
	/// 幻象/望月
	/// 在这个状态下，[幻象/乱弹]的效果改变：每次触发[幻象/乱弹]时失去1层[狂气]，使[幻象/乱弹]的伤害提升为100%，命中率提升为100%。
	/// 当[狂气]层数归零时、或是按下[等待]按钮时，[幻象/赤月]状态解除。
	/// </summary>
    public class B_Reisen_6:Buff
    {
        public override void Init()
        {
            base.Init();
            this.PlusPerStat.Damage = 30;
            this.PlusStat.DMGTaken = 50;
            this.PlusStat.Penetration = 100;
        }

        public override string DescExtended()
        {
            return base.DescExtended().Replace("&a", ((int)(this.BChar.GetStat.atk * 0.45)).ToString());
        }
    }
}