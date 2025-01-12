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
	/// 「完美女仆」
	/// 所有技能都能触发 [月魔术] 的额外效果。
	/// </summary>
    public class B_Sakuya_12Rare:Buff, IP_SkillUseHand_Team
    {
        public override void FixedUpdate()
        {
            base.FixedUpdate();
            if (BattleSystem.instance != null && BattleSystem.instance.AllyTeam.Skills.Count != 0)
            {
                if (BattleSystem.instance.AllyTeam.Skills[0].ExtendedFind_DataName("SE_Sakuya_Rare_12") == null)
                {
                    BattleSystem.instance.AllyTeam.Skills[0].ExtendedAdd(Skill_Extended.DataToExtended("SE_Sakuya_Rare_12"));
                }
                if (BattleSystem.instance.AllyTeam.Skills[BattleSystem.instance.AllyTeam.Skills.Count - 1].ExtendedFind_DataName("SE_Sakuya_Rare_12") == null)
                {
                    BattleSystem.instance.AllyTeam.Skills[BattleSystem.instance.AllyTeam.Skills.Count - 1].ExtendedAdd(Skill_Extended.DataToExtended("SE_Sakuya_Rare_12"));
                }
            }
        }

        public void SKillUseHand_Team(Skill skill)
        {
            if (!skill.BasicSkill && skill.Master == this.BChar)
            {
                if (BattleSystem.instance != null && BattleSystem.instance.AllyTeam.Skills.Count != 0)
                {
                    if (skill == BattleSystem.instance.AllyTeam.Skills[0] || skill == BattleSystem.instance.AllyTeam.Skills[BattleSystem.instance.AllyTeam.Skills.Count - 1])
                    {
                        BattleSystem.instance.AllyTeam.Draw(1);
                        BattleSystem.instance.AllyTeam.AP++;
                    }
                }
            }
        }
    }
}