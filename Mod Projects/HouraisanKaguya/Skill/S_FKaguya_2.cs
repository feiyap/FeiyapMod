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
	/// 难题「佛御石之钵　-不碎的意志-」
	/// 使用时立即施加&a(20%最大体力值)的保护罩。
	/// 倒计时结束时，移除保护罩；保护罩被清空时，倒计时立即结束。
	/// 难题 - 倒计时期间，除了自己以外的友军不使用手中的技能。
	/// </summary>
    public class S_FKaguya_2:Skill_Extended, IP_SkillUseHand_Team, IP_SkillCastingStart
    {
        public int count;

        public int bHP
        {
            get
            {
                return (int)((float)(0 + this.BChar.GetStat.maxhp * 0.35));
            }
        }

        public void SkillCasting(CastingSkill ThisSkill)
        {
            ThisSkill.Target.BuffAdd("B_FKaguya_2", this.BChar, false, 0, false, -1, false).BarrierHP += bHP;
            count = 0;
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);
            if (Targets[0].BuffFind("B_FKaguya_2"))
            {
                Targets[0].BuffReturn("B_FKaguya_2").BarrierHP = 0;
                Targets[0].BuffReturn("B_FKaguya_2").SelfDestroy();
            }

            //if (count == 0)
            //{
            //    this.BChar.BuffAdd("B_FKaguya_Sinnpou", this.BChar, false, 0, false, -1, false);
            //}
        }

        public override string DescExtended(string desc)
        {
            return base.DescExtended(desc).Replace("&a", (this.bHP).ToString());
        }

        public void SKillUseHand_Team(Skill skill)
        {
            if (skill.Master != this.BChar)
            {
                count++;
            }
        }
    }
}