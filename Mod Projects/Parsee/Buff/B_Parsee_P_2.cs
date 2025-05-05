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
namespace Parsee
{
	/// <summary>
	/// 妒火重置
	/// </summary>
    public class B_Parsee_P_2: Buff, IP_SkillUseHand_Team
    {
        public int count = 0;

        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
            count = 0;
            this.LucySkillExBuff = (BuffSkillExHand)Skill_Extended.DataToExtended("SE_Parsee_P_2");
        }

        public override bool CanSkillBuffAdd(Skill AddedSkill, int Index)
        {
            return AddedSkill.Master == this.BChar && (AddedSkill.IsDamage || AddedSkill.IsHeal) && AddedSkill.ExtendedFind_DataName("SE_Parsee_P_2") == null;
        }

        public void SKillUseHand_Team(Skill skill)
        {
            if (skill.Master == this.BChar)
            {
                count++;
            }
            if (count >= 2)
            {
                BattleSystem.DelayInput(this.Delete());
            }
        }
        
        public IEnumerator Delete()
        {
            base.SelfDestroy(false);
            yield return null;
            yield break;
        }
    }
}