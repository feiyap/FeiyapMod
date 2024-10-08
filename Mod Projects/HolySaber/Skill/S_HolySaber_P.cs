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
namespace HolySaber
{
	/// <summary>
	/// 进化
	/// 拥有[进化点]时才可使用。
	/// 消耗1个[进化点]，使手中1个可[进化]的技能触发[进化]效果。
	/// </summary>
    public class S_HolySaber_P: SkillExtended_HolySaber
    {
        public override bool SkillTargetSelectExcept(Skill ExceptSkill)
        {
            bool isLucyD = false;
            if (ExceptSkill.Master.IsLucyNoC || ExceptSkill == this.MySkill || ExceptSkill.ExtendedFind_DataName("SE_HolySaber_Extend") == null || ExceptSkill.ExtendedFind_DataName("SE_HolySaber_Extended") != null || ExceptSkill.MySkill.KeyID == "S_HolySaber_4")
            {
                isLucyD = true;
            }
            return isLucyD;
        }

        public override bool Terms()
        {
            if (this.BChar.BuffFind("B_HolySaber_P", false))
            {
                return true;
            }
            return false;
        }

        public override void SkillTargetSingle(List<Skill> Targets)
        {
            base.SkillTargetSingle(Targets);

            if (this.BChar.BuffFind("B_HolySaber_P", false))
            {
                this.BChar.BuffReturn("B_HolySaber_P").SelfStackDestroy();
                SkillChange(Targets[0]);
            }
        }
    }
}