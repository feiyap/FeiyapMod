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
	/// 十六夜咲夜
	/// Passive:
	/// 咲夜每次打出位于手牌顶或手牌底的技能时（[月计时]除外），获得1层[时钟停摆]。每获得5次[时钟停摆]后，将1张[月计时]加入手中。
	/// </summary>
    public class P_IzayoiSakuya:Passive_Char, IP_SkillUseHand_Team
    {
        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
        }

        public void SKillUseHand_Team(Skill skill)
        {
            if (!skill.BasicSkill && skill.Master == this.BChar && skill.MySkill.KeyID != "S_Sakuya_P" && skill.MySkill.KeyID != "S_Sakuya_0_0" && skill.MySkill.KeyID != "S_Public_29")
            {
                if (skill == BattleSystem.instance.AllyTeam.Skills[BattleSystem.instance.AllyTeam.Skills.Count - 1]
                    || skill == BattleSystem.instance.AllyTeam.Skills[0])
                {
                    this.BChar.BuffAdd("B_Sakuya_P_0", this.BChar, false, 0, false, -1, false);
                }
            }
        }
    }
}