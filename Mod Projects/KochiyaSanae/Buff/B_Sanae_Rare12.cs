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
namespace KochiyaSanae
{
	/// <summary>
	/// 神风的奇迹
	/// 使手中所有[风灵]的暴击率+100%。
	/// </summary>
    public class B_Sanae_Rare12:Buff
    {
        public int fixCount = 0;
        public override void FixedUpdate()
        {
            base.FixedUpdate();
            fixCount++;
            if (fixCount >= 12)
            {
                fixCount = 0;
                foreach (Skill skill in this.BChar.MyTeam.Skills)
                {
                    if ((skill.TargetDamage >= 1 || skill.TargetHeal >= 1) &&
                        (
                        skill.MySkill.KeyID == "S_FSL_Common" ||
                        skill.MySkill.KeyID == "S_Sanae_P" ||
                        skill.MySkill.KeyID == "S_Kanako_P" ||
                        skill.MySkill.KeyID == "S_Suwako_P" ||
                        skill.MySkill.KeyID == "S_Shameimaru_P"
                        )
                        && skill.ExtendedFind_DataName("SE_Sanae_Rare12") == null)
                    {
                        skill.ExtendedAdd(Skill_Extended.DataToExtended("SE_Sanae_Rare12"));
                    }
                }
            }
        }
    }
}