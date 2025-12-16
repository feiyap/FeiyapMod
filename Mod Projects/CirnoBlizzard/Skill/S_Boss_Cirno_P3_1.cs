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
namespace CirnoBlizzard
{
	/// <summary>
	/// 冰花之舞
	/// <b>无法闪避</b>
	/// 将伤害分摊给非濒死状态的所有调查员。
	/// 若全部处于濒死状态，则击杀所有调查员。
	/// </summary>
    public class S_Boss_Cirno_P3_1:Skill_Extended
    {
        public int NowDamage
        {
            get
            {
                return (int)(this.BChar.GetStat.atk * 4);
            }
        }

        public override void Init()
        {
            base.Init();
            this.EnemyTargetAIOnly = true;
            this.IsDamage = true;
        }

        public List<BattleChar> TargetAI(BattleEnemy MyBchar)
        {
            List<BattleChar> list = new List<BattleChar>();
            foreach (BattleChar battleChar in BattleSystem.instance.AllyTeam.AliveChars)
            {
                if (!battleChar.BuffFind(GDEItemKeys.Buff_B_Neardeath, false))
                {
                    list.Add(battleChar);
                }
            }
            if (list.Count == 0)
            {
                list.AddRange(BattleSystem.instance.AllyTeam.AliveChars);
                return list;
            }
            int num = this.NowDamage;
            num /= list.Count;
            this.SkillBasePlus.Target_BaseDMG = num;
            return list;
        }
    }
}