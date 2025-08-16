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
	/// 试验中「歌莉娅人形」
	/// 这个技能处于倒计时中时，为&user提供“+5攻击力，+5治疗力，+10最大体力值，+25%暴击率，+25%闪避率，+40%无法战斗抵抗”。
	/// 这个技能处于倒计时中时，使其他「人形」技能的效果变为：恢复 1 点法力值并抽取 1 个技能。
	/// 触发时，对所有敌人造成一次伤害。
	/// 每触发 3 次后，下 1 次触发改为对所有敌人造成 &a 伤害(攻击力的450%)。然后将这个技能放逐。
	/// </summary>
    public class S_FAlice_Rare_3_0 : SkillExtended_FAlice, IP_SkillCastingStart, IP_SkillCastingQuit
    {
        public override string DescExtended(string desc)
        {
            return base.DescExtended(desc).Replace("&user", this.BChar.Info.Name).
                Replace("&a", ((int)(this.BChar.GetStat.atk * (4.5f + this.PlusPerATK / 100f))).ToString());
        }

        public override void NormalEffect()
        {
            base.NormalEffect();
            Skill skill = this.MySkill.CloneSkill(true, this.BChar);
            skill.MySkill.Target = new GDEs_targettypeData(GDEItemKeys.s_targettype_all_enemy);
            BattleSystem.DelayInput(BattleSystem.instance.SkillRandomUseIenum(this.BChar, skill, false, true, false));
        }

        public override void EnhancedEffect()
        {
            base.EnhancedEffect();
            Skill skill = this.MySkill.CloneSkill(true, this.BChar);
            skill.MySkill.Target = new GDEs_targettypeData(GDEItemKeys.s_targettype_all_enemy);
            S_FAlice_Rare_3_0 se = skill.ExtendedFind<S_FAlice_Rare_3_0>();
            if (se != null)
            {
                se.PlusSkillPerStat.Damage = 300;
            }
            BattleSystem.DelayInput(BattleSystem.instance.SkillRandomUseIenum(this.BChar, skill, false, true, false));
            this.CastingWaste();
        }

        public new void SkillCasting(CastingSkill ThisSkill)
        {
            base.SkillCasting(ThisSkill);
            this.BChar.BuffAdd(ModItemKeys.Buff_B_FAlice_Rare_3_0, this.BChar);
        }

        public void SkillCastingQuit(CastingSkill ThisSkill)
        {
            this.BChar.BuffRemove(ModItemKeys.Buff_B_FAlice_Rare_3_0, true);
        }
    }
}