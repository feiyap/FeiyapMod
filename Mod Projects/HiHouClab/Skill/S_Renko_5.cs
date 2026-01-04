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
	/// 伊奘诺物质
	/// 在本回合内可重复释放。
	/// 根据场上持有“量子纠缠”的敌方单位的数量，提升这个技能的费用；
	/// 根据场上持有“量子纠缠”的我方单位的数量，降低这个技能的费用。
	/// </summary>
    public class S_Renko_5:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);

            Skill tmpSkill = Skill.TempSkill("S_Renko_5", this.BChar, this.BChar.MyTeam);
            tmpSkill.isExcept = true;
            BattleSystem.instance.AllyTeam.Add(tmpSkill, true);
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            int count = 0;
            foreach (BattleAlly ba in BattleSystem.instance.AllyList)
            {
                if (ba.BuffFind("B_Renko_5"))
                {
                    count--;
                }
            }
            foreach (BattleEnemy be in BattleSystem.instance.EnemyList)
            {
                if (be.BuffFind("B_Renko_5"))
                {
                    count++;
                }
            }
            this.APChange = count;
        }
    }
}