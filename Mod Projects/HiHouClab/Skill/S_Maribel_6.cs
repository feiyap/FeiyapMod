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
	/// 禁忌的膜壁
	/// 这个技能不会因为回合结束而被释放。
	/// 倒计时期间，当目标受到伤害时，消耗这个技能的剩余治疗量，立即治疗目标。
	/// 这个技能的治疗量不大于0时立即释放。
	/// </summary>
    public class S_Maribel_6:Skill_Extended, IP_SkillCastingStart, IP_SkillCastingQuit, IP_DamageTake
    {
        public bool isCast = false;
        public BattleChar bc = new BattleChar();

        public override void Init()
        {
            base.Init();
            this.CountingExtedned = true;
            isCast = false;
        }

        public void SkillCasting(CastingSkill ThisSkill)
        {
            bc = ThisSkill.TargetReturn()[0];
            BasicMethods.CustomMethods.CountingSkillNotUseTurnEnd(ThisSkill, -1);
            isCast = true;
        }

        public void SkillCastingQuit(CastingSkill ThisSkill)
        {
            bc = null;
            isCast = false;
        }

        public void DamageTake(BattleChar User, int Dmg, bool Cri, ref bool resist, bool NODEF = false, bool NOEFFECT = false, BattleChar Target = null)
        {
            if (!isCast)
            {
                return;
            }

            if (Target.Info.Ally && bc && Target == bc)
            {
                this.SkillBasePlus.Target_BaseHeal -= Dmg;
                //Target.Heal(this.BChar, Dmg, false, false, null);
                BattleSystem.instance.StartCoroutine(this.Heal(Target, Dmg));
            }

            if (this.BChar.GetStat.reg * 1.3 + this.SkillBasePlus.Target_BaseHeal <= 0)
            {
                foreach (CastingSkill castingSkill in BattleSystem.instance.CastSkills)
                {
                    if (castingSkill.skill == this.MySkill)
                    {
                        BattleSystem.instance.ActWindow.CastingWaste(castingSkill);
                        BattleSystem.instance.StartCoroutine(BattleSystem.instance.AllyCastingSkillUse(castingSkill, false));
                        BattleSystem.instance.CastSkills.Remove(castingSkill);
                        break;
                    }
                }
            }
        }

        public IEnumerator Heal(BattleChar Char, int Dmg)
        {
            yield return new WaitForSecondsRealtime(0.1f);
            Char.Heal(this.BChar, Dmg, false, false, null);
            yield break;
        }
    }
}