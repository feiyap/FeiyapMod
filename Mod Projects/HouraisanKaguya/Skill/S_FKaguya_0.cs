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
	/// 难题「龙颈之玉　-五色的弹丸-」
	/// 向未受伤的敌人释放时，抽取1个技能。
	/// 难题 - 己方未拥有体力极限的人数不少于拥有体力极限的人数。
	/// </summary>
    public class S_FKaguya_0:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            if (Targets[0].HP == Targets[0].GetStat.maxhp)
            {
                BattleSystem.instance.AllyTeam.Draw(1);
            }
            
            int count1 = BattleSystem.instance.AllyList.Count;
            List<BattleAlly> list = new List<BattleAlly>();
            foreach (BattleAlly battleAlly in BattleSystem.instance.AllyList)
            {
                bool flag2 = battleAlly.Info.Hp == battleAlly.Recovery;
                if (flag2)
                {
                    list.Add(battleAlly);
                }
            }
            int count2 = list.Count;
            bool flag3 = count2 >= (count1 - count2);
            if (flag3)
            {
                this.BChar.BuffAdd("B_FKaguya_Sinnpou", this.BChar, false, 0, false, -1, false);
            }
        }
    }
}