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
namespace Inaba
{
	/// <summary>
	/// 影符「暗月下的逃逸」
	/// 生成1张仅能指向相同阵营单位的[影符「暗月下的误导」]。
	/// </summary>
    public class S_Inaba_7:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            foreach (BattleEnemy be in Targets)
            {
                be.BuffAdd("B_Inaba_P_5", this.BChar);
            }

            BattleSystem.DelayInputAfter(this.EffectAllBomb());
            //EffectAllBomb();
        }

        public IEnumerator EffectAllBomb()
        {
            yield return new WaitForSeconds(0.05f);

            foreach (BattleChar bc in BattleSystem.instance.AllyList)
            {
                if (bc.BuffFind("B_Inaba_P_5"))
                {
                    bc.BuffReturn("B_Inaba_P_5")?.SelfDestroy();
                    Skill skill = Skill.TempSkill("S_Inaba_P_5_0", this.BChar, this.BChar.MyTeam);
                    skill.PlusHit = true;
                    skill.FreeUse = true;
                    this.BChar.ParticleOut(this.MySkill, skill, bc);
                }
            }

            foreach (BattleChar bc in BattleSystem.instance.EnemyList)
            {
                if (bc.BuffFind("B_Inaba_P_5"))
                {
                    bc.BuffReturn("B_Inaba_P_5")?.SelfDestroy();
                    Skill skill = Skill.TempSkill("S_Inaba_P_5_0", this.BChar, this.BChar.MyTeam);
                    skill.PlusHit = true;
                    skill.FreeUse = true;
                    this.BChar.ParticleOut(this.MySkill, skill, bc);
                }
            }

            yield return null;
            yield break;
        }
    }
}