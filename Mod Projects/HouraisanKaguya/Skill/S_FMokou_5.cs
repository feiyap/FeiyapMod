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
namespace HouraisanKaguya
{
	/// <summary>
	/// 蓬莱「凯风快晴 -Fujiyama Volcano-」
	/// 指向<color=purple>烧伤</color>层数最多的敌人。
	/// 根据目标身上的<color=purple>烧伤</color>层数，重复释放这个技能。
	/// 那之后，清空自己和目标身上所有的<color=purple>烧伤</color>。
	/// </summary>
    public class S_FMokou_5:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);

            if (!this.MySkill.FreeUse && Targets[0].BuffFind("B_Mokou_T_1"))
            {
                List<BattleChar> list = new List<BattleChar>();
                Skill skill = Skill.TempSkill("S_FMokou_5", this.BChar, this.BChar.MyTeam);
                skill.FreeUse = true;
                list.AddRange((this.BChar as BattleEnemy).Ai.TargetSelect(skill));
                for (int i = 0; i < Targets[0].BuffReturn("B_Mokou_T_1", false).StackNum; i++)
                {
                    //BattleSystem.instance.EnemyCastEnqueue(this.BChar as BattleEnemy, skill, list, BattleSystem.instance.AllyTeam.TurnActionNum, false);
                    this.BChar.ParticleOut(skill, Targets);
                }
                
                Targets[0].BuffReturn("B_Mokou_T_1").SelfDestroy();
            }

            if (this.BChar.BuffFind("B_Mokou_T_1"))
            {
                this.BChar.BuffReturn("B_Mokou_T_1").SelfDestroy();
            }
        }
    }
}