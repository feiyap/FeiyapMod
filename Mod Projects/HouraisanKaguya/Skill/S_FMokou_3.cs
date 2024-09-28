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
	/// 炎符「自灭火焰大旋风」
	/// <color=orange>过热：2 - 以倒计时1重复释放1次。</color>
	/// </summary>
    public class S_FMokou_3:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);
            if (this.BChar.BuffFind("B_Mokou_T_1") && this.BChar.BuffReturn("B_Mokou_T_1", false).StackNum >= 2)
            {
                if (!this.MySkill.FreeUse)
                {
                    List<BattleChar> list = new List<BattleChar>();
                    Skill skill = Skill.TempSkill("S_FMokou_3", this.BChar, this.BChar.MyTeam);
                    skill.FreeUse = true;
                    list.AddRange((this.BChar as BattleEnemy).Ai.TargetSelect(skill));
                    BattleSystem.instance.EnemyCastEnqueue(this.BChar as BattleEnemy, skill, list, BattleSystem.instance.AllyTeam.TurnActionNum + 1, false);
                }

                int num = 0;
                for (int i = 0; i < 2; i++)
                {
                    bool flag = this.BChar.BuffFind("B_Mokou_T_1", false);
                    if (flag)
                    {
                        int num2 = this.BChar.BuffReturn("B_Mokou_T_1", false).Tick();
                        int stackNum = this.BChar.BuffReturn("B_Mokou_T_1", false).StackNum;
                        int num3 = (int)this.BChar.BuffReturn("B_Mokou_T_1", false).BuffData.LifeTime;
                        num += num2 / stackNum * num3;
                        this.BChar.BuffReturn("B_Mokou_T_1", false).SelfStackDestroy();
                    }
                }
                this.BChar.Damage(this.BChar, num, false, true, true, 0, false, false, false);
            }
        }
    }
}