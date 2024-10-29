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
using BasicMethods;
namespace Suwako
{
	/// <summary>
	/// 南风灵
	/// 这个技能被放回牌库时，放逐这个技能。
	/// </summary>
    public class S_Suwako_P:Skill_Extended, IP_SkillSelfToDeck
    {
        public void SelfAddToDeck(SkillLocation skillLoaction)
        {
            BattleSystem.instance.AllyTeam.Skills_Deck.Remove(this.MySkill);
        }
    }
}