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
	/// 暗符「雾之伦敦人形」
	/// 这个技能处于倒计时中时，为&user提供“+1速度”。
	/// 触发时，使所有友军获得“+25%闪避率、+25%减益抵抗率”，持续 1 回合。
	/// 每触发 3 次后，下 1 次触发还会使所有友军获得“下 1 个固定能力费用降低 1 点”。
	/// </summary>
    public class S_FAlice_5 : SkillExtended_FAlice, IP_SkillCastingStart, IP_SkillCastingQuit
    {
        public override string DescExtended(string desc)
        {
            return base.DescExtended(desc).Replace("&user", this.BChar.Info.Name);
        }

        public override void NormalEffect()
        {
            base.NormalEffect();

            Skill skill = this.MySkill.CloneSkill(true, this.BChar);
            skill.MySkill.Target = new GDEs_targettypeData(GDEItemKeys.s_targettype_enemy);
            BattleSystem.DelayInput(BattleSystem.instance.SkillRandomUseIenum(this.BChar, skill, false, true, false));
        }

        public override void EnhancedEffect()
        {
            base.EnhancedEffect();

            Skill skill = this.MySkill.CloneSkill(true, this.BChar);
            skill.MySkill.Target = new GDEs_targettypeData(GDEItemKeys.s_targettype_enemy);
            BattleSystem.DelayInput(BattleSystem.instance.SkillRandomUseIenum(this.BChar, skill, false, true, false));

            foreach (BattleChar battleChar in BattleSystem.instance.AllyTeam.AliveChars)
            {
                (battleChar as BattleAlly).MyBasicSkill?.buttonData?.ExtendedAdd(new BattleFlag_Ex());
            }

        }

        public new void SkillCasting(CastingSkill ThisSkill)
        {
            base.SkillCasting(ThisSkill);
            this.BChar.BuffAdd(ModItemKeys.Buff_B_FAlice_5_0, this.BChar);
        }

        public void SkillCastingQuit(CastingSkill ThisSkill)
        {
            this.BChar.BuffRemove(ModItemKeys.Buff_B_FAlice_5_0, true);
        }
    }
}