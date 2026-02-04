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
namespace FeiyapTank
{
	/// <summary>
	/// 哑光
	/// 叠加至 2 层时，自身从手中打出的下 1 个的攻击技能会消耗所有“哑光”层数并施加(100%干扰)眩晕。
	/// </summary>
    public class B_FeiyapTank_1:Buff
    {
        public override void FixedUpdate()
        {
            base.FixedUpdate();
            if (this.BChar.BuffReturn("B_FeiyapTank_1").StackNum >= 2)
            {
                this.LucySkillExBuff = (BuffSkillExHand)Skill_Extended.DataToExtended("SE_FeiyapTank_1");
            }
        }

        public override bool CanSkillBuffAdd(Skill AddedSkill, int Index)
        {
            return AddedSkill.Master == this.BChar && AddedSkill.IsDamage && AddedSkill.ExtendedFind_DataName("SE_FeiyapTank_1") == null;
        }
    }
}