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
	/// 苍符「博爱的奥尔良人形」
	/// 这个技能处于倒计时中时，为&user提供“+1治疗力”。
	/// 触发时，对体力值最低的、已受伤的友军治疗一次。
	/// 每触发 3 次后，下 1 次触发改为对所有友军造成治疗。
	/// </summary>
    public class S_FAlice_2 : SkillExtended_FAlice, IP_SkillCastingStart, IP_SkillCastingQuit
    {
        public override string DescExtended(string desc)
        {
            return base.DescExtended(desc).Replace("&user", this.BChar.Info.Name);
        }

        public override void NormalEffect()
        {
            base.NormalEffect();
            Skill skill = this.MySkill.CloneSkill(true, this.BChar);
            skill.MySkill.Target = new GDEs_targettypeData(GDEItemKeys.s_targettype_ally);
            BattleChar target = BattleSystem.instance.AllyTeam.AliveChars
                .FindAll(bc => bc.HP < bc.GetStat.maxhp)
                .OrderBy(bc => bc.HP)
                .FirstOrDefault();
            if (target != null)
            {
                BattleSystem.DelayInput(BattleSystem.instance.ForceAction(skill, target, false, false, true));
            }
            else
            {
                BattleSystem.DelayInput(BattleSystem.instance.SkillRandomUseIenum(this.BChar, skill, false, true, false));
            }
        }

        public override void EnhancedEffect()
        {
            base.EnhancedEffect();
            Skill skill = this.MySkill.CloneSkill(true, this.BChar);
            skill.MySkill.Target = new GDEs_targettypeData(GDEItemKeys.s_targettype_all_ally);
            BattleSystem.DelayInput(BattleSystem.instance.SkillRandomUseIenum(this.BChar, skill, false, true, false));
        }

        public new void SkillCasting(CastingSkill ThisSkill)
        {
            base.SkillCasting(ThisSkill);
            this.BChar.BuffAdd(ModItemKeys.Buff_B_FAlice_2, this.BChar);
        }

        public void SkillCastingQuit(CastingSkill ThisSkill)
        {
            this.BChar.BuffRemove(ModItemKeys.Buff_B_FAlice_2, true);
        }
    }
}