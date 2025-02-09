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
namespace Yuyuko
{
	/// <summary>
	/// 「反魂蝶」
	/// 握在手中时，自身每次进入永眠状态时，使这个技能获得：打出时，重复释放1次。
	/// 这个技能最多能重复释放10次。
	/// 葬送 - 将这个技能拿回手中，并使这个技能获得：打出时，重复释放1次。
	/// 幽冥蝶 - 
	/// 人魂蝶 - 
	/// </summary>
    public class S_YuyukoF_Rare_1:Skill_Extended, IP_BuffAddAfter, IP_SkillSelfExcept
    {
        public void BuffaddedAfter(BattleChar BuffUser, BattleChar BuffTaker, Buff addedbuff, StackBuff stackBuff)
        {
            if (BuffTaker == this.BChar && addedbuff.BuffData.Key == "B_YuyukoF_P_3")
            {

            }
        }

        public bool SelfExcept(SkillLocation skillLoaction)
        {
            
            return true;
        }
    }
}