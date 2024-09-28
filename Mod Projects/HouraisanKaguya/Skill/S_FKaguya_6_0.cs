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
namespace HouraisanKaguya
{
	/// <summary>
	/// 难题「燕的子安贝　-永命线-」
	/// 本回合内可重复释放一次。
	/// 难题 - 这个回合自身受到的伤害大于自身最大生命值的20%(&a)（当前为&b）。
	/// </summary>
    public class S_FKaguya_6_0:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            if (this.BChar.BuffFind("B_FKaguya_6_0"))
            {
                this.BChar.BuffAdd("B_FKaguya_Sinnpou", this.BChar, false, 0, false, -1, false);
            }
        }

        public override string DescExtended(string desc)
        {
            return base.DescExtended(desc).Replace("&a", (this.PlusDmg).ToString());
        }

        public int PlusDmg
        {
            get
            {
                if (BattleSystem.instance == null || BattleSystem.instance.BattleLogs == null || BattleSystem.instance.TurnNum <= 0)
                {
                    return 0;
                }
                return (int)((float)(0 + this.BChar.GetStat.maxhp * 0.2));
            }
        }
    }
}