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
	/// 诅咒「魔彩光的上海人形」
	/// 这个技能处于倒计时中时，为&user提供“+1攻击力”。
	/// 触发时，对随机敌人造成一次伤害。
	/// 每触发 3 次后，下 1 次触发改为对所有敌人造成伤害。
	/// </summary>
    public class S_FAlice_1 : SkillExtended_FAlice, IP_SkillCastingStart, IP_SkillCastingQuit
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
            skill.MySkill.Target = new GDEs_targettypeData(GDEItemKeys.s_targettype_all_enemy);
            BattleSystem.DelayInput(BattleSystem.instance.SkillRandomUseIenum(this.BChar, skill, false, true, false));
        }

        public new void SkillCasting(CastingSkill ThisSkill)
        {
            base.SkillCasting(ThisSkill);
            this.BChar.BuffAdd(ModItemKeys.Buff_B_FAlice_1, this.BChar);
        }

        public void SkillCastingQuit(CastingSkill ThisSkill)
        {
            this.BChar.BuffRemove(ModItemKeys.Buff_B_FAlice_1, true);
        }
    }
}