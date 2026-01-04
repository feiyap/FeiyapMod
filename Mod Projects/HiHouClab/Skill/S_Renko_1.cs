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
    /// 科学世纪的少年少女
    /// 同时攻击除该目标外 1 个持有“量子纠缠”的敌人；否则生成 1 个“伊奘诺物质”。
    /// </summary>
    public class S_Renko_1:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);

            bool isAdd = false;

            foreach (BattleEnemy be in BattleSystem.instance.EnemyList)
            {
                if (be.BuffFind("B_Renko_5") && be != Targets[0])
                {
                    Targets.Add(be);
                    isAdd = true;
                    break;
                }
            }

            if (!isAdd)
            {
                Skill tmpSkill = Skill.TempSkill("S_Renko_5", this.BChar, this.BChar.MyTeam);
                tmpSkill.isExcept = true;
                BattleSystem.instance.AllyTeam.Add(tmpSkill, true);
            }
        }
    }
}