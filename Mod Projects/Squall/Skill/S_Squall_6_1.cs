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
	/// 使1个敌人将会最先释放的攻击技能立即释放，斯考尔替友军承受此技能的总伤害量。
	/// </summary>
    public class S_Squall_6_1:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            this.BChar.BuffAdd("B_Squall_0", this.BChar);
            foreach (CastingSkill castingSkill in (Targets[0] as BattleEnemy).SkillQueue)
            {
                castingSkill.CastSpeed = 0;
                break;
            }

            BattleSystem.instance.StartCoroutine(BattleSystem.instance.EnemyTurn(false));
            base.SkillUseSingle(SkillD, Targets);
        }
    }
}