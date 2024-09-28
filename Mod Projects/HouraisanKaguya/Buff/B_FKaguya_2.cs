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
namespace HouraisanKaguya
{
	/// <summary>
	/// 佛御石之钵
	/// </summary>
    public class B_FKaguya_2:Buff, IP_SkillUseHand_Team
    {
        public int count;

        public override void Init()
        {
            base.Init();
            count = 0;
        }

        public IEnumerator Counter(CastingSkill CastingSkill)
        {
            yield return BattleSystem.instance.StartCoroutine(BattleSystem.instance.AllyCastingSkillUse(CastingSkill, false));
            BattleSystem.instance.CastSkills.Remove(CastingSkill);
            BattleSystem.instance.SaveSkill.Remove(CastingSkill);
            this.PlusStat.Strength = false;
            yield return null;
            yield break;
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();

            if (base.Usestate_L.IsDead)
            {
                base.SelfDestroy(false);
            }
        }

        public override void SelfdestroyPlus()
        {
            base.SelfdestroyPlus();
            if (count == 0)
            {
                base.Usestate_F.BuffAdd("B_FKaguya_Sinnpou", this.BChar, false, 0, false, -1, false);
            }
            foreach (CastingSkill castingSkill in BattleSystem.instance.CastSkills)
            {
                if (castingSkill.Usestate == base.Usestate_L && castingSkill.skill.MySkill.KeyID == "S_FKaguya_2")
                {
                    BattleSystem.DelayInput(this.Counter(castingSkill));
                    return;
                }
            }
            foreach (CastingSkill castingSkill2 in BattleSystem.instance.SaveSkill)
            {
                if (castingSkill2.Usestate == base.Usestate_L && castingSkill2.skill.MySkill.KeyID == "S_FKaguya_2")
                {
                    BattleSystem.DelayInput(this.Counter(castingSkill2));
                    break;
                }
            }
        }

        public void SKillUseHand_Team(Skill skill)
        {
            if (skill.Master != base.Usestate_F)
            {
                count++;
            }
        }
    }
}