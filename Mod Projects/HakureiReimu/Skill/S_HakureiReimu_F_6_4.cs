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
namespace HakureiReimu
{
	/// <summary>
	/// 大结界「博丽弹幕结界」
	/// 以倒计时2的形式重复释放1次。
	/// </summary>
    public class S_HakureiReimu_F_6_4: S_HakureiReimu_F_6
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            if (!this.MySkill.FreeUse)
            {
                Skill skill = Skill.TempSkill("S_HakureiReimu_F_6_4", this.BChar, this.BChar.MyTeam);
                skill.FreeUse = true;
                skill.Counting = 2;

                BattleSystem.DelayInputAfter(this.PassiveAttack(skill, Targets[0]));
            }
        }
    }
}