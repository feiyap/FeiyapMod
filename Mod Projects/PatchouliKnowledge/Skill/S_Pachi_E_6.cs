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
	/// 高级元素 - 月
	/// 象征“权力”的权能。
	/// 使用时，在本次战斗期间“月”元素等级提升 1 级。
	/// 每个等级的“月”提供1点额外最大法力值。
	/// </summary>
    public class S_Pachi_E_6:Skill_Extended
    {
        public override bool ButtonSelectTerms()
        {
            if (!P_PatchouliKnowledge.HasValidFirstElement())
            {
                return true;
            }
            BV_Pachi_P bv = P_PatchouliKnowledge.GetElementBattleValue();
            if (bv == null)
            {
                return true;
            }
            if (P_PatchouliKnowledge.firstskill.MySkill.KeyID == "S_Pachi_E_0")
            {
                return bv.moonUsed[0] == 0;
            }
            if (P_PatchouliKnowledge.firstskill.MySkill.KeyID == "S_Pachi_E_1")
            {
                return bv.moonUsed[1] == 0;
            }
            if (P_PatchouliKnowledge.firstskill.MySkill.KeyID == "S_Pachi_E_2")
            {
                return bv.moonUsed[2] == 0;
            }
            if (P_PatchouliKnowledge.firstskill.MySkill.KeyID == "S_Pachi_E_3")
            {
                return bv.moonUsed[3] == 0;
            }
            if (P_PatchouliKnowledge.firstskill.MySkill.KeyID == "S_Pachi_E_4")
            {
                return bv.moonUsed[4] == 0;
            }
            if (P_PatchouliKnowledge.firstskill.MySkill.KeyID == "S_Pachi_E_5")
            {
                return bv.sunUsed[6] == 0;
            }
            if (P_PatchouliKnowledge.firstskill.MySkill.KeyID == "S_Pachi_E_6")
            {
                return bv.moonUsed[6] == 0;
            }
            return true;
        }
    }
}