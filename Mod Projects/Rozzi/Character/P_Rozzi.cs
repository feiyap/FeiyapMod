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
namespace Rozzi
{
	/// <summary>
	/// 洛兹
	/// Passive:
	/// 洛兹使用自己的专属技能后，下1个使用的非专属技能会释放2次，但每次只造成70%伤害。
	/// </summary>
    public class P_Rozzi:Passive_Char, IP_SkillUseHand_Team
    {
        public void SKillUseHand_Team(Skill skill)
        {
            if (skill.Master == this.BChar && BattleSystem.instance.BattleLogs != null)
            {

            }
        }
    }
}