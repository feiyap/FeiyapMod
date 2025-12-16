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
namespace Jhin
{
	/// <summary>
	/// 大幕渐起
	/// <color=red>无法使用“完美谢幕”以外的技能。</color>
	/// 回合结束时解除，或在打出“完美谢幕 - 谢幕曲”时解除。
	/// </summary>
    public class B_Jhin_Rare_1:Buff, IP_TurnEnd, IP_SkillUseHand_Team
    {
        public override void Init()
        {
            base.Init();
            this.PlusStat.dod = -300;
        }

        public override void BuffOneAwake()
        {
            base.BuffOneAwake();
            this.LucySkillExBuff = (BuffSkillExHand)Skill_Extended.DataToExtended("SE_Jhin_Rare_1");
        }

        public void TurnEnd()
        {
            this.SelfDestroy();
        }

        public override bool CanSkillBuffAdd(Skill AddedSkill, int Index)
        {
            return AddedSkill.Master == this.BChar && AddedSkill.ExtendedFind_DataName("SE_Jhin_Rare_1") == null &&
                AddedSkill.MySkill.KeyID != "S_Jhin_Rare_1_1" &&
                AddedSkill.MySkill.KeyID != "S_Jhin_Rare_1_2" &&
                AddedSkill.MySkill.KeyID != "S_Jhin_Rare_1_3" &&
                AddedSkill.MySkill.KeyID != "S_Jhin_Rare_1_4";
        }

        public void SKillUseHand_Team(Skill skill)
        {
            if (skill.MySkill.KeyID == "S_Jhin_Rare_1_4")
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