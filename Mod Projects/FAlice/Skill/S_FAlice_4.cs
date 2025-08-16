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
namespace FAlice
{
	/// <summary>
	/// 红符「红发的荷兰人形」
	/// 这个技能处于倒计时中时，为&user提供“-1速度”。
	/// 触发时，使所有友军获得“+25%暴击率、+25%暴击伤害”，持续 1 回合。
	/// 每触发 3 次后，下 1 次触发还会使所有友军获得“+1攻击力”。
	/// </summary>
    public class S_FAlice_4 : SkillExtended_FAlice, IP_SkillCastingStart, IP_SkillCastingQuit
    {
        public override string DescExtended(string desc)
        {
            return base.DescExtended(desc).Replace("&user", this.BChar.Info.Name);
        }

        public override void NormalEffect()
        {
            base.NormalEffect();
            foreach (BattleChar battleChar in BattleSystem.instance.AllyTeam.AliveChars)
            {
                battleChar.BuffAdd(ModItemKeys.Buff_B_FAlice_4_1, this.BChar);
            }
        }

        public override void EnhancedEffect()
        {
            base.EnhancedEffect();
            foreach (BattleChar battleChar in BattleSystem.instance.AllyTeam.AliveChars)
            {
                battleChar.BuffAdd(ModItemKeys.Buff_B_FAlice_4_1, this.BChar);
                battleChar.BuffAdd(ModItemKeys.Buff_B_FAlice_4_2, this.BChar);
            }

        }

        public new void SkillCasting(CastingSkill ThisSkill)
        {
            base.SkillCasting(ThisSkill);
            this.BChar.BuffAdd(ModItemKeys.Buff_B_FAlice_4_0, this.BChar);
        }

        public void SkillCastingQuit(CastingSkill ThisSkill)
        {
            this.BChar.BuffRemove(ModItemKeys.Buff_B_FAlice_4_0, true);
        }
    }
}