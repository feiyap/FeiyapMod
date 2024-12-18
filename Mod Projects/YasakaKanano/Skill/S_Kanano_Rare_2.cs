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
	/// 「神明的威光」
	/// 从弃牌库中尽可能地将0费技能拿回手中。
	/// </summary>
    public class S_Kanano_Rare_2:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            List<Skill> list = new List<Skill>();

            foreach (Skill skill in BattleSystem.instance.AllyTeam.Skills_UsedDeck)
            {
                if (skill._AP == 0)
                {
                    list.Add(skill);
                }
            }

            for (int i = 0; i < 10 - BattleSystem.instance.AllyTeam.Skills.Count; i++)
            {
                this.BChar.MyTeam.ForceDraw(list[i]);
            }
        }
    }
}