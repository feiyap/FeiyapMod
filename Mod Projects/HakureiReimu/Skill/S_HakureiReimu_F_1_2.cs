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
namespace HakureiReimu
{
	/// <summary>
	/// 宝具「阴阳鬼神玉」
	/// 自身每有1种增益效果，进行1次额外攻击（最多4次）。
	/// </summary>
    public class S_HakureiReimu_F_1_2: S_HakureiReimu_F_1
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            int count = CheckBuffNum();

            BattleSystem.DelayInput(this.Effect2(Targets[0], count));
        }

        public IEnumerator Effect2(BattleChar Target, int Count)
        {
            yield return new WaitForSeconds(0.15f);
            int num;
            for (int i = 0; i < Count; i = num + 1)
            {
                if (BattleSystem.instance.EnemyTeam.AliveChar_GetInstance().Count != 0)
                {
                    Skill skill = Skill.TempSkill("S_HakureiReimu_F_1_EX", this.BChar, this.BChar.MyTeam);
                    skill.MySkill.Effect_Target.DMG_Per = 30;
                    skill.PlusHit = true;
                    if (Target.IsDead && BattleSystem.instance.EnemyTeam.AliveChars.Count != 0)
                    {
                        this.BChar.ParticleOut(this.MySkill, skill, BattleSystem.instance.EnemyTeam.AliveChars.Random(this.BChar.GetRandomClass().Main));
                    }
                    else
                    {
                        this.BChar.ParticleOut(this.MySkill, skill, Target);
                    }
                }
                yield return new WaitForSeconds(0.1f);
                num = i;
            }
            yield break;
        }

        public override string DescExtended(string desc)
        {
            return base.DescExtended(desc).Replace("&a", ((int)(this.BChar.GetStat.atk * 0.3f)).ToString());
        }
    }
}