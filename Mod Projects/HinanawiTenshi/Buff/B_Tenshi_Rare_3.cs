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
namespace HinanawiTenshi
{
	/// <summary>
	/// 天气 - 绯想天
	/// 手中的技能附加迅速。
	/// </summary>
    public class B_Tenshi_Rare_3:Buff
    {
        public override void FixedUpdate()
        {
            base.FixedUpdate();
            if (BattleSystem.instance != null && BattleSystem.instance.AllyTeam.Skills.Count != 0)
            {
                foreach (Skill skill in BattleSystem.instance.AllyTeam.Skills)
                {
                    if (skill.ExtendedFind_DataName("SE_Tenshi_Rare_3") == null)
                    {
                        skill.ExtendedAdd(Skill_Extended.DataToExtended("SE_Tenshi_Rare_3"));
                    }
                }
            }
        }
    }
}