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
namespace HiHouClab
{
	/// <summary>
	/// 少女秘封俱乐部
	/// 打出时，使所有目标的体力恢复至体力上限。
	/// 这个技能从倒计时栏离开时，使所有敌人受到等量于治疗量的量子伤害。
	/// </summary>
    public class S_Maribel_Rare_1:Skill_Extended, IP_SkillCastingStart, IP_SkillCastingQuit
    {
        public Dictionary<BattleChar, int> healList;

        public override void Init()
        {
            base.Init();
            this.CountingExtedned = true;
        }

        public void SkillCasting(CastingSkill ThisSkill)
        {
            healList = new Dictionary<BattleChar, int>();

            foreach (BattleChar bc in BattleSystem.instance.AllyList)
            {
                int healnum = bc.GetStat.maxhp - bc.HP;
                bc.Heal(this.BChar, healnum, false, true, null);
            }
            foreach (BattleChar bc in BattleSystem.instance.EnemyList)
            {
                int healnum = bc.GetStat.maxhp - bc.HP;
                if (healnum > 0)
                {
                    bc.Heal(this.BChar, healnum, false, true, null);
                    healList[bc] = healnum;
                }
                
            }
        }

        public void SkillCastingQuit(CastingSkill ThisSkill)
        {
            foreach (var kvp in healList)
            {
                BattleChar bc = kvp.Key;
                int healnum = kvp.Value;
                bc.QuantumDamage(this.BChar, healnum, false);
            }
        }
    }
}