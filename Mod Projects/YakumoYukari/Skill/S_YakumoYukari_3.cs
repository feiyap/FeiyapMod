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
    /// 静观其变之眼
    /// 迅捷动作，自身。强制推进一次倒计时，获得 1 点境界力。
    /// </summary>
    public class S_YakumoYukari_3 : SE_YakumoYukari_Action
    {
        protected override void ApplyKeyDefaults()
        {
            this.ActionType = YukariActionType.Swift;
            this.CannotLevel = true;
            this.ForceTick = true;
            this.BoundaryCost = 0;
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);
            BV_YakumoYukari_P bv = BV_YakumoYukari_P.Get();
            if (bv != null)
            {
                bv.GainBoundary(1, this.BChar);
            }
        }
    }
}
