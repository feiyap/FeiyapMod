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
namespace YasakaKanano
{
	/// <summary>
	/// 神奈子基类
	/// </summary>
    public class Skillbase_Kanano:Skill_Extended
    {
        //连击X
        public bool CheckUsedSkills(int count)
        {
            return BattleSystem.instance.BattleLogs.getSkills((BattleLog log) => log.WhoUse.Info.Ally, (Skill skill) => !skill.FreeUse, BattleSystem.instance.TurnNum).Count >= count;
        }

        //穗收X
        public bool CheckDeck1(int count, bool preview)
        {
            if (BattleSystem.instance.AllyTeam.Skills_Deck.Count >= count)
            {
                if (!preview)
                {
                    for (int i = count - 1; i >= 0; i--)
                    {
                        Skill tmpskill = BattleSystem.instance.AllyTeam.Skills_Deck[i];
                        BattleSystem.instance.AllyTeam.Skills_Deck.Remove(tmpskill);
                        BattleSystem.instance.AllyTeam.Skills_UsedDeck.Insert(0, tmpskill);
                    }
                }
                return true;
            }
            return false;
        }

        //饥馑X
        public bool CheckDeck2(int count)
        {
            return BattleSystem.instance.AllyTeam.Skills_Deck.Count <= count;
        }
    }
}