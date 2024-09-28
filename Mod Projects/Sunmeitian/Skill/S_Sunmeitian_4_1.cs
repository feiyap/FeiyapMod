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
namespace Sunmeitian
{
	/// <summary>
	/// 丛林之舞（近）
	/// 使所有敌人行动倒计时-1。
	/// </summary>
    public class S_Sunmeitian_4_1:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);

            using (List<BattleEnemy>.Enumerator enumerator = BattleSystem.instance.EnemyList.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    BattleEnemy battleEnemy = enumerator.Current;
                    foreach (CastingSkill castingSkill in battleEnemy.SkillQueue)
                    {
                        castingSkill._CastSpeed -= 1;
                    }
                }
            }

            Skill tmpSkill = Skill.TempSkill("S_Sunmeitian_4_2", this.BChar, this.BChar.MyTeam);
            tmpSkill.isExcept = true;
            BattleSystem.instance.AllyTeam.Add(tmpSkill, true);
        }
    }
}