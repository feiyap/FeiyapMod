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
	/// 风雨欲来
	/// 下次触发旋回效果时，使被旋回的技能在本场战斗中增加&a(40%)伤害或&b(65%)治疗量。
	/// </summary>
    public class B_Suwako_8:Buff, IP_OnSkillAddToDeck
    {
        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
        }

        public IEnumerator OnSkillAddToDeck(Dictionary<Skill, SkillLocation> AddToDeck_Skills)
        {
            Skill tmpSkill = Skill.TempSkill("S_Suwako_P", this.BChar, this.BChar.MyTeam);
            BattleSystem.instance.AllyTeam.Add(tmpSkill, true);

            yield return null;
            yield break;
        }
    }
}