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
	/// 爆裂禁区
	/// </summary>
    public class S_Squall_Rare_3:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            this.SkillBasePlus.Target_BaseDMG += (int)(this.BChar.GetStat.def * 0.5f);

            for (int i = 0; i < 15; i++)
            {
                BattleSystem.DelayInput(this.Effect(Targets[0]));
            }
        }

        public IEnumerator Effect(BattleChar bc)
        {
            for (int i = 0; i < BattleSystem.instance.EnemyList.Count; i++)
            {
                Skill skill = Skill.TempSkill("S_Squall_Rare_3_0", this.BChar, this.BChar.MyTeam);
                skill.PlusHit = true;
                skill.FreeUse = true;
                Skill_Extended se = new Skill_Extended();
                se.SkillBasePlus.Target_BaseDMG = (int)(this.BChar.GetStat.def * 0.5f);
                skill.ExtendedAdd(se);

                if (bc != null || bc.IsDead)
                {
                    this.BChar.ParticleOut(skill, bc);
                }
                else if (BattleSystem.instance.EnemyTeam.AliveChars.Count != 0)
                {
                    this.BChar.ParticleOut(skill, BattleSystem.instance.EnemyTeam.AliveChars.Random(this.BChar.GetRandomClass().Main));
                }
            }

            yield return new WaitForSeconds(0.1f);
            yield break;
        }

        public override string DescExtended(string desc)
        {
            return base.DescExtended(desc).Replace("&a", ((int)(this.BChar.GetStat.def * 0.5f)).ToString());
        }
    }
}