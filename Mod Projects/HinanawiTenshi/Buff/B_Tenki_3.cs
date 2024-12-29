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
	/// 天气 - 云天
	/// </summary>
    public class B_Tenki_3:Buff
    {
        public override void FixedUpdate()
        {
            base.FixedUpdate();
            if (BattleSystem.instance != null && BattleSystem.instance.AllyTeam.Skills.Count != 0)
            {
                if (BattleSystem.instance.AllyTeam.Skills[0].ExtendedFind_DataName("SE_Tenki_3") == null)
                {
                    BattleSystem.instance.AllyTeam.Skills[0].ExtendedAdd(Skill_Extended.DataToExtended("SE_Tenki_3"));
                }
                if (BattleSystem.instance.AllyTeam.Skills[BattleSystem.instance.AllyTeam.Skills.Count - 1].ExtendedFind_DataName("SE_Tenki_3") == null)
                {
                    BattleSystem.instance.AllyTeam.Skills[BattleSystem.instance.AllyTeam.Skills.Count - 1].ExtendedAdd(Skill_Extended.DataToExtended("SE_Tenki_3"));
                }
            }
        }
    }
}