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
	/// 开海的奇迹
	/// 手中所有的0费技能获得迅速，造成&a(20%)额外伤害或&b(20%)额外治疗。
	/// </summary>
    public class B_Sanae_Rare10:Buff
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
                    if ((skill.TargetDamage >= 1 || skill.TargetHeal >= 1) && skill.AP == 0 && skill.ExtendedFind_DataName("SE_Sanae_Rare10") == null)
                    {
                        skill.ExtendedAdd(Skill_Extended.DataToExtended("SE_Sanae_Rare10"));
                    }
                }
            }
        }

        public override string DescExtended()
        {
            return base.DescExtended().Replace("&a", ((int)(base.Usestate_L.GetStat.atk * 0.3f)).ToString()).Replace("&b", ((int)(base.Usestate_L.GetStat.reg * 0.3f)).ToString());
        }
    }
}