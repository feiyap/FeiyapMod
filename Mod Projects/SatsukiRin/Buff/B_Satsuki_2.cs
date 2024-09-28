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
namespace SatsukiRin
{
	/// <summary>
	/// 季风
	/// 下个回合开始时，优先抽取1个自己的攻击技能。
	/// </summary>
    public class B_Satsuki_2:Buff, IP_PlayerTurn
    {
        public void Turn()
        {
            BattleTeam.DrawInput a = null;

            Skill skill2 = BattleSystem.instance.AllyTeam.Skills_Deck.Find((Skill skill) => (skill.IsDamage && skill.Master == this.BChar));
            if (skill2 == null)
            {
                BattleSystem.instance.AllyTeam.Draw();
            }
            else
            {
                BattleSystem.instance.AllyTeam.ForceDraw(skill2, a);
            }

            this.SelfDestroy();
        }
    }
}