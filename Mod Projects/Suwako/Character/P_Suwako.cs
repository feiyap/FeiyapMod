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
	/// 洩矢诹访子
	/// Passive:
	/// </summary>
    public class P_Suwako:Passive_Char, IP_OnSkillAddToDeck
    {
        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
        }

        public IEnumerator OnSkillAddToDeck(List<Skill> AddToDeck_Skills)
        {
            Debug.Log("A");
            BattleSystem instance = BattleSystem.instance;
            if (((instance != null) ? instance.EnemyTeam : null) == null)
            {
                yield break;
            }
            this.BChar.BuffAdd("B_Suwako_0", this.BChar);
            Debug.Log("B");
            List<Skill> list = AddToDeck_Skills.FindAll((Skill x) => x.Master == this.BChar);
            if (list != null && list.Count > 0)
            {
                Debug.Log("C");
                this.BChar.BuffAdd("B_Suwako_0", this.BChar);
            }

            yield break;
        }
    }
}