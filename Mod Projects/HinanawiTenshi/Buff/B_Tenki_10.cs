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
	/// 天气 - 疏雨
	/// 手中的稀有技能的费用降低1点。
	/// </summary>
    public class B_Tenki_10:Buff
    {
        public override void FixedUpdate()
        {
            base.FixedUpdate();
            if (BattleSystem.instance != null && BattleSystem.instance.AllyTeam.Skills.Count != 0)
            {
                foreach (Skill skill in BattleSystem.instance.AllyTeam.Skills)
                {
                    if (skill.Master == this.BChar && skill.MySkill.Rare)
                    {
                        skill.APChange = -1;
                    }
                }
            }
        }
    }
}