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
	/// 须臾之见
	/// 自身的下 1 个技能附带迅速。
	/// </summary>
    public class B_Renko_6:Buff, IP_SkillUse_User_After
    {
        public override void Init()
        {
            base.Init();
            this.LucySkillExBuff = (Skill_Extended.DataToExtended("SE_Renko_6") as BuffSkillExHand);
        }

        public override bool CanSkillBuffAdd(Skill AddedSkill, int Index)
        {
            return AddedSkill.Master == this.BChar && AddedSkill.ExtendedFind_DataName("SE_Renko_6") == null;
        }

        public void SkillUseAfter(Skill SkillD)
        {
            if (SkillD.Master == this.BChar)
            {
                base.SelfDestroy(false);
            }
        }
    }
}