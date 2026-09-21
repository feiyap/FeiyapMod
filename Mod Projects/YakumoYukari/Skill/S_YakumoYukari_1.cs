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
    /// 后悔打开的玉匣
    /// 标准动作，指向敌人，100%倍率。
    /// </summary>
    public class S_YakumoYukari_1 : SE_YakumoYukari_Action
    {
        protected override void ApplyKeyDefaults()
        {
            this.ActionType = YukariActionType.Standard;
            this.CannotLevel = true;
            this.ForceTick = false;
            this.BoundaryCost = 0;
        }

        public override string DescExtended(string desc)
        {
            string text = base.DescExtended(desc);
            if (this.BChar != null)
            {
                text = text.Replace("&a", ((int)Misc.PerToNum((float)this.BChar.GetStat.atk, 100f)).ToString());
            }
            return text;
        }
    }
}
