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
namespace Kirito
{
	/// <summary>
	/// 垂直弧形斩
	/// 依据选择的后宫团成员获得额外效果：
	/// -亚丝娜：下个出手的技能附加迅速。
	/// -诗乃：击杀敌人时，会触发一次额外的[狙击支援]。
	/// -尤吉欧：所有敌人获得目标身上等量的冻伤层数。
	/// </summary>
    public class S_Kirito_2:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            BattleSystem.instance.AllyTeam.Draw();

            if (this.BChar.BuffFind("B_Asuna_P", false))
            {
                this.BChar.BuffAdd("B_Asuna_1", this.BChar, false, 0, false, -1, false);
            }

            if (this.BChar.BuffFind("B_Shino_P", false))
            {
                
            }

            if (this.BChar.BuffFind("B_Eugeo_P", false))
            {
                int num = Targets[0].BuffReturn("B_Eugeo_P_0_0", false).StackNum;
                using (List<BattleChar>.Enumerator enumerator = BattleSystem.instance.EnemyTeam.AliveChars.GetEnumerator())
                {
                    while (enumerator.MoveNext())
                    {
                        BattleChar battleChar = enumerator.Current;
                        for (int i = 0;i < num;i++)
                        {
                            battleChar.BuffAdd("B_Eugeo_P_0_0", this.BChar, false, 0, false, -1, false);
                        }
                    }
                }
            }
        }

        public override void SkillKill(SkillParticle SP)
        {
            base.SkillKill(SP);
            if (this.BChar.BuffFind("B_Shino_P", false))
            {
                BattleSystem.DelayInputAfter(this.Ienum());
            }
        }

        public IEnumerator Ienum()
        {
            Skill skill = Skill.TempSkill("S_Shino_0", this.BChar, this.BChar.MyTeam);
            this.BChar.ParticleOut(skill, BattleSystem.instance.EnemyTeam.AliveChars.Random(this.BChar.GetRandomClass().Main));

            yield return new WaitForSecondsRealtime(0.1f);
            yield break;
        }
    }
}