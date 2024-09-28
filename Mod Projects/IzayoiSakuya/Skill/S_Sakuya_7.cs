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
namespace IzayoiSakuya
{
	/// <summary>
	/// 幻术「吾刃回归」
	/// 使1个技能释放后放回牌堆顶。
	/// </summary>
    public class S_Sakuya_7:Skill_Extended
    {
        public override void SkillTargetSingle(List<Skill> Targets)
        {
            base.SkillTargetSingle(Targets);
            //Targets[0].ExtendedAdd("SE_Sakuya_7_0");

            if (Targets[0].ExtendedFind_DataName("SE_Sakuya_P") == null)
            {
                Targets[0].ExtendedAdd("SE_Sakuya_7_0");
            }
            else
            {
                //SE_Sakuya_7 extended = new SE_Sakuya_7();
                Targets[0].ExtendedAdd_Battle("SE_Sakuya_7");
                return;
            }
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