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
	/// 水平四方斩
	/// 依据选择的后宫团成员获得额外效果：
	/// -亚丝娜：重复释放一次。不会触发[后宫团]效果。
	/// -诗乃：施加1层[锁定]：受到暴击率+10%，受到暴击伤害+10%。2回合。
	/// -尤吉欧：如果只有1个目标，额外施加2层[冻伤]。
	/// </summary>
    public class S_Kirito_1:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            if (this.BChar.BuffFind("B_Asuna_P", false))
            {
                BattleSystem.DelayInputAfter(this.Ienum());
            }

            if (this.BChar.BuffFind("B_Shino_P", false))
            {
                for (int i = 0; i < Targets.Count; i++)
                {
                    if (Targets[i] is BattleEnemy)
                    {
                        Targets[i].BuffAdd("B_Shino_1", this.BChar, false, 0, false, -1, false);
                    }
                }
            }

            if (this.BChar.BuffFind("B_Eugeo_P", false))
            {
                if (Targets.Count == 1)
                {
                    Targets[0].BuffAdd("B_Eugeo_P_0_0", this.BChar, false, 0, false, -1, false);
                    Targets[0].BuffAdd("B_Eugeo_P_0_0", this.BChar, false, 0, false, -1, false);
                }
            }
        }

        public IEnumerator Ienum()
        {
            Skill skill = Skill.TempSkill("S_Kirito_1", this.BChar, this.BChar.MyTeam);
            Skill_Extended extended = new Skill_Extended();
            skill.ExtendedAdd(extended);
            skill.isExcept = true;
            skill.FreeUse = true;
            skill.PlusHit = true;
            this.BChar.ParticleOut(this.MySkill, skill, this.BChar.BattleInfo.EnemyList.Random(this.BChar.GetRandomClass().Main));
            yield return new WaitForSecondsRealtime(0.01f);
            yield break;
        }
    }
}