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
namespace szb_elena
{
	/// <summary>
	/// 世界·捷尔加内亚
	/// 仅能在自身体力低于&a时使用(自身最大体力值的75%)。
	/// (120%干扰)眩晕攻击力最高的敌人。
	/// 治疗体力最低的友军&a(180%)点体力。
	/// 抽取2个技能。
	/// </summary>
    public class S_szb_elena_10:Skill_Extended
    {
        public override string DescExtended(string desc)
        {
            return base.DescExtended(desc).Replace("&a", ((int)(this.BChar.GetStat.maxhp * 0.75)).ToString()).Replace("&b", ((int)(this.BChar.GetStat.reg * 1.8)).ToString());
        }
        public override bool Terms()
        {  
            if (this.BChar.HP >= this.BChar.GetStat.maxhp * 0.75)
            {
                return false;
            }
            return true;
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            float num = 0;
            BattleChar result = null;
            foreach (BattleChar battleChar in BattleSystem.instance.EnemyTeam.AliveChars)
            {
                if (num < battleChar.GetStat.atk)
                {
                    result = battleChar;
                    num = battleChar.GetStat.atk;
                }
            }
            result.BuffAdd(GDEItemKeys.Buff_B_Common_Rest, this.BChar, false, 120, false, -1, false);
            BattleSystem.instance.AllyTeam.FindChar_LowHP().Heal(this.BChar, (float)(this.BChar.GetStat.reg*1.8), false, false, null);
            BattleSystem.instance.AllyTeam.Draw(2);
        }
    }
}