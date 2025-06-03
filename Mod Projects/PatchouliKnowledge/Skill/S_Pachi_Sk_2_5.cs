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
using BasicMethods;
namespace PatchouliKnowledge
{
	/// <summary>
	/// 日水符「氢化日珥」
	/// </summary>
    public class S_Pachi_Sk_2_5:Skill_Extended, IP_SkillCastingStart, IP_DamageTake
    {
        public override void Init()
        {
            base.Init();
            this.CountingExtedned = true;
        }

        public void SkillCasting(CastingSkill ThisSkill)
        {
            BasicMethods.CustomMethods.CountingSkillNotUseTurnEnd(ThisSkill, -1);
        }

        public void DamageTake(BattleChar User, int Dmg, bool Cri, ref bool resist, bool NODEF = false, bool NOEFFECT = false, BattleChar Target = null)
        {
            if (Target.Info.Ally)
            {
                this.SkillBasePlus.Target_BaseHeal -= Dmg;
                Target.Heal(this.BChar, Dmg, false, false, null);
            }

            if (this.BChar.GetStat.atk * 3 + this.SkillBasePlus.Target_BaseHeal < 0)
            {
                foreach (CastingSkill castingSkill in BattleSystem.instance.CastSkills)
                {
                    if (castingSkill.skill == this.MySkill)
                    {
                        BattleSystem.instance.ActWindow.CastingWaste(castingSkill);
                        BattleSystem.instance.StartCoroutine(BattleSystem.instance.AllyCastingSkillUse(castingSkill, false));
                        BattleSystem.instance.CastSkills.Remove(castingSkill);
                    }
                }
            }
        }
    }
}