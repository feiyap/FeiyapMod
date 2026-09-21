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

namespace YakumoYukari
{
    /// <summary>
    /// 潜藏于禅寺的妖蝶
    /// 整轮动作：消耗 1 移动 + 1 标准，180% 倍率，推进 1 次倒计时。
    /// </summary>
    public class S_YakumoYukari_2 : SE_YakumoYukari_Action
    {
        protected override void ApplyKeyDefaults()
        {
            this.ActionType = YukariActionType.FullRound;
            this.CannotLevel = true;
            this.ForceTick = false;
            this.BoundaryCost = 0;
        }

        public override string DescExtended(string desc)
        {
            string text = base.DescExtended(desc);
            if (this.BChar != null)
            {
                text = text.Replace("&a", ((int)Misc.PerToNum((float)this.BChar.GetStat.atk, 180f)).ToString());
            }
            return text;
        }
    }
}
