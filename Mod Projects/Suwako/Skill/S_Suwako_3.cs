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
	/// 土著神「御射军神大人」
	/// <color=#008B45>旋回</color> - 放逐这个技能，恢复2点法力值。
	/// </summary>
    public class S_Suwako_3:Skill_Extended, IP_SkillSelfToDeck
    {
        public void SelfAddToDeck(SkillLocation skillLoaction)
        {
            this.MySkill.Except();
            BattleSystem.instance.AllyTeam.AP += 2;
        }
    }
}