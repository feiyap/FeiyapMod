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
	/// 消耗1层刃甲，选择：
	/// - 使1个敌人将会最先释放的攻击技能立即释放，斯考尔替友军承受此技能的总伤害量。
	/// - 使1个敌人本回合中将会最先释放的1个攻击技能延后1回合。
	/// </summary>
    public class S_Squall_6:Skill_Extended, IP_SkillUse_Target
    {
        public override bool Terms()
        {
            return this.BChar.BuffFind("B_Squall_P");
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            this.BChar.BuffReturn("B_Squall_P")?.SelfStackDestroy();

            this.BChar.BuffAdd("B_Sqaull_6", this.BChar);

            //BattleSystem.DelayInputAfter(Del2(SkillD, Targets));
        }

        public void AttackEffect(BattleChar hit, SkillParticle SP, int DMG, bool Cri)
        {
            if ((SP.SkillData == this.MySkill))
            {
                BattleSystem.DelayInputAfter(Del2(SP.SkillData, hit));
            }
        }

        public IEnumerator Del2(Skill SkillD, BattleChar Target)
        {
            yield return new WaitForSecondsRealtime(0.25f);

            foreach (CastingSkill castingSkill in (Target as BattleEnemy).SkillQueue)
            {
                castingSkill.CastSpeed = 0;
                break;
            }

            BattleSystem.instance.StartCoroutine(BattleSystem.instance.EnemyTurn(false));

            yield break;
        }
    }
}