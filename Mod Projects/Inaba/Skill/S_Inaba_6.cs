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
namespace Inaba
{
	/// <summary>
	/// 幸符「幸运的白色魔法」
	/// 这场战斗中仅有一次，目标技能的暴击率+50%，并在释放时从<color=gold>帝的豪华奖池</color>中随机触发1个效果。
	/// </summary>
    public class S_Inaba_6:Skill_Extended
    {
        public override void SkillTargetSingle(List<Skill> Targets)
        {
            base.SkillTargetSingle(Targets);

            Targets[0].ExtendedAdd("SE_Inaba_6");
        }

        public override bool SkillTargetSelectExcept(Skill ExceptSkill)
        {
            bool isLucyD = false;
            if (ExceptSkill.Master.IsLucyNoC || ExceptSkill == this.MySkill)
            {
                isLucyD = true;
            }
            return isLucyD;
        }
    }
}