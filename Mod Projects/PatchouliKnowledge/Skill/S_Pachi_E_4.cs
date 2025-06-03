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
namespace PatchouliKnowledge
{
	/// <summary>
	/// 基本元素 - 土
	/// 使用时，在本次战斗期间“土”元素等级提升 1 级。
	/// 每个等级的“土”提供4%防御力。
	/// </summary>
    public class S_Pachi_E_4:Skill_Extended
    {
        public override bool ButtonSelectTerms()
        {
            if (P_PatchouliKnowledge.firstskill == null)
            {
                return true;
            }
            if (P_PatchouliKnowledge.firstskill.MySkill.KeyID == "S_Pachi_E_5")
            {
                return BattleSystem.instance.GetBattleValue<BV_Pachi_P>().sunUsed[4] == 0;
            }
            if (P_PatchouliKnowledge.firstskill.MySkill.KeyID == "S_Pachi_E_6")
            {
                return BattleSystem.instance.GetBattleValue<BV_Pachi_P>().moonUsed[4] == 0;
            }
            return true;
        }
    }
}