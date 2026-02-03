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
namespace HiHouClab
{
	/// <summary>
	/// 幻透的错觉
	/// 调查员使用倒计时技能时，每点倒计时为该增益提供“暴击率+10%，暴击伤害+10%，暴击治疗+10%”（每个技能最多计算&a点，不超过&user当前等级）。
	/// </summary>
    public class B_Maribel_4:Buff, IP_SkillUseHand_Team
    {
        int count = 0;

        public override void Init()
        {
            base.Init();
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            this.PlusStat.cri = 10 * count;
            this.PlusStat.PlusCriDmg = 10 * count;
            this.PlusStat.PlusCriHeal = 10 * count;
        }
        public override string DescInit()
        {
            return base.DescInit().Replace("&a", ((int)(this.BChar.Info.LV)).ToString())
                                  .Replace("&user", this.BChar.Info.Name);
        }

        public void SKillUseHand_Team(Skill skill)
        {
            if (skill.Counting > 0)
            {
                count += Math.Max(skill.Counting, 3);
            }
        }
    }
}