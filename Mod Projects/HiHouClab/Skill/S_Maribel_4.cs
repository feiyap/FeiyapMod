using BasicMethods;
using ChronoArkMod;
using ChronoArkMod.Plugin;
using ChronoArkMod.Template;
using DarkTonic.MasterAudio;
using GameDataEditor;
using I2.Loc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;
namespace HiHouClab
{
	/// <summary>
	/// 特洛伊群的密林
	/// 倒计时期间，目标的暴击率提升100%。
	/// </summary>
    public class S_Maribel_4:Skill_Extended, IP_SkillCastingStart, IP_SkillCastingQuit
    {
        public override void Init()
        {
            base.Init();
            this.CountingExtedned = true;
        }
        public void SkillCasting(CastingSkill ThisSkill)
        {
            ThisSkill.Target.BuffAdd("B_Maribel_4_1", this.BChar);
        }

        public void SkillCastingQuit(CastingSkill ThisSkill)
        {
            //BattleSystem.DelayInputAfter(this.Del(ThisSkill));
        }

        private IEnumerator Del(CastingSkill ThisSkill)
        {
            yield return new WaitForFixedUpdate();
            if (!BattleSystem.instance.CastSkills.Any((CastingSkill i) => i != ThisSkill && i.skill.MySkill.KeyID == "S_Maribel_4" && i.Target == ThisSkill.Target) && !BattleSystem.instance.SaveSkill.Any((CastingSkill i) => i != ThisSkill && i.skill.MySkill.KeyID == "S_Maribel_4" && i.Target == ThisSkill.Target))
            {
                ThisSkill.Target.BuffRemove("B_Maribel_4");
            }
            yield break;
        }
    }
}