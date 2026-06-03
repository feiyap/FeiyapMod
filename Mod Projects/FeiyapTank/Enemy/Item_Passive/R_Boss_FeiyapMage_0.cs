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
namespace FeiyapTank
{
    /// <summary>
    /// 嬉笑魔女的博爱
    /// 使用攻击技能后，下 1 个技能的治疗量提升33%。
    /// 使用治疗技能后，下 1 个技能的伤害量提升33%。
    /// </summary>
    public class R_Boss_FeiyapMage_0 : PassiveItemBase, IP_SkillUseHand_Team
    {
        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
        }

        public void SKillUseHand_Team(Skill skill)
        {
            if (skill.IsDamage)
            {
                base.ShinyEffect();
                BattleSystem.instance.AllyTeam.LucyAlly.BuffAdd("B_R_Boss_FeiyapMage_0", BattleSystem.instance.AllyTeam.LucyAlly, false, 0, false, -1, false);
            }
            if (skill.IsHeal)
            {
                base.ShinyEffect();
                BattleSystem.instance.AllyTeam.LucyAlly.BuffAdd("B_R_Boss_FeiyapMage_1", BattleSystem.instance.AllyTeam.LucyAlly, false, 0, false, -1, false);
            }
        }
    }
}