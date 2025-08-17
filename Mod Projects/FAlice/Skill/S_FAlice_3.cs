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
	/// 白符「白垩的俄罗斯人形」
	/// 这个技能处于倒计时中时，为&user提供“+4%防御力”。
	/// 触发时，获得 &a 防护墙(60%防御力)。
	/// 每触发 3 次后，下 1 次触发还会使所有友军获得“保护体力极限”，持续 2 回合。
	/// </summary>
    public class S_FAlice_3 : SkillExtended_FAlice, IP_SkillCastingStart, IP_SkillCastingQuit
    {
        public override string DescExtended(string desc)
        {
            return base.DescExtended(desc).Replace("&user", this.BChar.Info.Name)
                .Replace("&a", ((int)(this.BChar.GetStat.def * (0.6f + this.PlusPerDEF / 100f))).ToString())
                .Replace("&d", ((int)(this.PlusBuff)).ToString());
        }

        public override void NormalEffect()
        {
            base.NormalEffect();
            Skill skill = this.MySkill.CloneSkill(true, this.BChar);
            skill.MySkill.Target = new GDEs_targettypeData(GDEItemKeys.s_targettype_enemy);
            
            for (int i = 0; i < PlusBuff; i++)
            {
                BattleSystem.DelayInput(BattleSystem.instance.SkillRandomUseIenum(this.BChar, skill, false, true, false));
            }
        }

        public override void EnhancedEffect()
        {
            base.EnhancedEffect();

            Skill skill = this.MySkill.CloneSkill(true, this.BChar);
            skill.MySkill.Target = new GDEs_targettypeData(GDEItemKeys.s_targettype_enemy);
            for (int i = 0; i < PlusBuff; i++)
            {
                BattleSystem.DelayInput(BattleSystem.instance.SkillRandomUseIenum(this.BChar, skill, false, true, false));
            }

            int barrier = (int)(this.BChar.GetStat.def * (0.6f + this.PlusPerDEF / 100f));
            BattleSystem.instance.AllyTeam.partybarrier.BarrierHP += barrier;

            foreach (BattleChar battleChar in BattleSystem.instance.AllyTeam.AliveChars)
            {
                battleChar.BuffAdd(ModItemKeys.Buff_B_FAlice_3_1, this.BChar);
            }
        }

        public new void SkillCasting(CastingSkill ThisSkill)
        {
            base.SkillCasting(ThisSkill);
            this.BChar.BuffAdd(ModItemKeys.Buff_B_FAlice_3_0, this.BChar);
        }

        public void SkillCastingQuit(CastingSkill ThisSkill)
        {
            this.BChar.BuffRemove(ModItemKeys.Buff_B_FAlice_3_0, true);
        }
    }
}