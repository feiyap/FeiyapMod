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
namespace FlandreScarlet
{
	/// <summary>
	/// 禁忌游戏
	/// </summary>
    public class B_FlandreScarlet_7_0:Buff, IP_PlayerTurn
    {
        public void Turn()
        {
            BattleTeam.DrawInput a = null;

            Skill skill2 = BattleSystem.instance.AllyTeam.Skills_Deck.Find((Skill skill) => (skill.Master == this.BChar));
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