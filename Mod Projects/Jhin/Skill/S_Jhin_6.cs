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
namespace Jhin
{
	/// <summary>
	/// 华丽收场
	/// <color=red>仅能在法力值消耗为 4 时打出。</color>
	/// 若剩余法力值为 4，改为指向最多 4 个敌人。
	/// 若牌库剩余数量为 4，这个技能的伤害变为 &a (攻击力的4444%)。
	/// </summary>
    public class S_Jhin_6:Skill_Extended
    {
        public override bool Terms()
        {
            return base.Terms() && this.MySkill.AP == 4;
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);
            
            if (this.BChar.MyTeam.AP == 0)
            {
                foreach (BattleChar battleChar in BattleSystem.instance.EnemyTeam.AliveChars)
                {
                    if (battleChar != Targets[0] && Targets.Count < 4)
                    {
                        Targets.Add(battleChar);
                    }
                }
            }

            if (BattleSystem.instance.AllyTeam.Skills_Deck.Count == 4)
            {
                this.SkillBasePlus.Target_BaseDMG = (int)(this.BChar.GetStat.atk * 12.34f);
            }
        }

        public override string DescExtended(string desc)
        {
            return base.DescExtended(desc).Replace("&a", ((int)(this.BChar.GetStat.atk * 12.34f)).ToString());
        }
    }
}