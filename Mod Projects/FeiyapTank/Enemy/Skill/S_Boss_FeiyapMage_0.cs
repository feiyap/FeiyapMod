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
namespace FeiyapTank
{
	/// <summary>
	/// 魔法飞弹
	/// 重复释放，次数等同于当前回合数。
	/// </summary>
    public class S_Boss_FeiyapMage_0:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            for (int i = 0 ; i < BattleSystem.instance.TurnNum ; i++)
            {
                BattleSystem.DelayInput(this.PlusAttack(Targets[0]));
            }
        }

        public IEnumerator PlusAttack(BattleChar hit)
        {
            yield return new WaitForSecondsRealtime(0.3f);
            Skill skill = Skill.TempSkill("S_Boss_FeiyapMage_0", this.BChar, this.BChar.MyTeam);
            if (this.BChar != null && !this.BChar.Dummy && !this.BChar.IsDead)
            {
                //if (!hit.IsDead)
                //{
                //    this.BChar.ParticleOut(this.MySkill, skill, hit);
                //}
                //else 
                if (BattleSystem.instance.EnemyList.Count > 0)
                {
                    this.BChar.ParticleOut(this.MySkill, skill, this.BChar.BattleInfo.AllyList.Random(this.BChar.GetRandomClass().Main));
                }
            }
            yield break;
        }
    }
}