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
	/// 风雨已至
	/// </summary>
    public class B_Suwako_Dot:Buff, IP_OnSkillAddToDeck
    {
        public int count;

        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
        }

        public IEnumerator OnSkillAddToDeck(Dictionary<Skill, SkillLocation> AddToDeck_Skills)
        {
            yield return null;

            count++;
            this.PlusDamageTick = count * 2;

            yield return null;
            yield break;
        }
    }
}