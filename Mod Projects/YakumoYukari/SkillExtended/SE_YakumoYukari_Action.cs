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
    /// 可转化动作的通用扩展：类型、境界力消耗、强制推进、不可升级。
    /// </summary>
    public class SE_YakumoYukari_Action : Skill_Extended
    {
        public YukariActionType ActionType = YukariActionType.Standard;
        public int BoundaryCost;
        public bool ForceTick;
        public bool CannotLevel = true;
        public YukariActionCost PendingCost;
        public bool HasPendingCost;

        public override void Init()
        {
            base.Init();
            this.ApplyKeyDefaults();
        }

        protected virtual void ApplyKeyDefaults()
        {
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);
            BV_YakumoYukari_P bv = BV_YakumoYukari_P.Get();
            if (bv == null)
            {
                return;
            }
            if (this.HasPendingCost)
            {
                bv.TrySpend(this.PendingCost);
                this.HasPendingCost = false;
            }
            if (this.BoundaryCost > 0)
            {
                bv.TrySpendBoundary(this.BoundaryCost);
            }
        }

        public override string DescExtended(string desc)
        {
            BV_YakumoYukari_P bv = BV_YakumoYukari_P.Get();
            string text = base.DescExtended(desc);
            if (bv != null && this.MySkill != null && this.MySkill.MySkill != null)
            {
                int lv = bv.GetActionLevel(this.MySkill.MySkill.KeyID);
                if (lv > 0)
                {
                    text = text.Replace("&lv", lv.ToString());
                }
            }
            return text;
        }
    }
}
