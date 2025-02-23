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
namespace Squall
{
	/// <summary>
	/// 静寂裁决
	/// 使1个敌人本回合中将会最先释放的1个攻击技能延后1回合。
	/// </summary>
    public class S_Squall_6_2:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            foreach (CastingSkill castingSkill in (Targets[0] as BattleEnemy).SkillQueue)
            {
                castingSkill.CastSpeed++;
                break;
            }

            base.SkillUseSingle(SkillD, Targets);
        }
    }
}