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
namespace ShameimaruAya
{
	/// <summary>
	/// 风来的少女
	/// 使用0费的技能时，恢复1点法力值。
	/// </summary>
    public class B_Shameimaru_Rare11:Buff, IP_SkillUse_Team
    {
        public void SkillUseTeam(Skill skill)
        {
            if (skill.Master == this.BChar && ((!skill.NotCount && skill.AP <= 1) || skill.AP <= 0))
            {
                BattleSystem.instance.AllyTeam.AP += 1;
            }
        }
    }
}