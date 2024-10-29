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
        public IEnumerator OnSkillAddToDeck(Dictionary<Skill, SkillLocation> AddToDeck_Skills)
        {
            foreach (KeyValuePair<Skill, SkillLocation> pair in AddToDeck_Skills)
            {
                pair.Key.ExtendedAdd_Battle(Skill_Extended.DataToExtended("SE_Suwako_Rare2"));
            }

            this.SelfDestroy();

            yield return null;
            yield break;
        }

        public override string DescExtended()
        {
            return base.DescExtended().Replace("&a", ((int)(base.Usestate_L.GetStat.atk * 0.4f)).ToString()).Replace("&b", ((int)(base.Usestate_L.GetStat.reg * 0.65f)).ToString());
        }
    }
}