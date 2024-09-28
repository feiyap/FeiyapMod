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
	/// 难题「燕的子安贝　-永命线-」
	/// 本回合内可重复释放一次。
	/// 难题 - 这个回合自身受到的伤害大于自身最大生命值的20%(&a)（当前为&b）。
	/// </summary>
    public class S_FKaguya_6:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            Skill skill = Skill.TempSkill("S_FKaguya_6_0", this.BChar, this.BChar.MyTeam);
            skill.isExcept = true;
            skill.AutoDelete = 1;
            this.BChar.MyTeam.Add(skill, true);

            if (this.BChar.BuffFind("B_FKaguya_6_0"))
            {
                this.BChar.BuffAdd("B_FKaguya_Sinnpou", this.BChar, false, 0, false, -1, false);
            }
        }

        public override string DescExtended(string desc)
        {
            return base.DescExtended(desc).Replace("&a", (this.PlusDmg).ToString());
        }

        public int PlusDmg
        {
            get
            {
                return (int)((float)(0 + this.BChar.GetStat.maxhp * 0.2));
            }
        }
    }
}