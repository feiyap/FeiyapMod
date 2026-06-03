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
	/// 嬉笑魔女的溺爱
	/// </summary>
    public class B_R_Boss_FeiyapMage_1:Buff
    {
        public override void Init()
        {
            base.Init();
            this.LucySkillExBuff = (BuffSkillExHand)Skill_Extended.DataToExtended("SE_B_R_Boss_FeiyapMage_1");
        }

        public override bool CanSkillBuffAdd(Skill AddedSkill, int Index)
        {
            return (AddedSkill.IsDamage) && AddedSkill.ExtendedFind_DataName("SE_B_R_Boss_FeiyapMage_1") == null;
        }
    }
}