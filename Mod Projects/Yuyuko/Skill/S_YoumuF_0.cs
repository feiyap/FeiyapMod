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
namespace Yuyuko
{
	/// <summary>
	/// 柄击
	/// 释放2次“柄击”后，追加1次“拔刀术”。
	/// </summary>
    public class S_YoumuF_0:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            B_YoumuF_P_0.zhoujinum++;

            if (B_YoumuF_P_0.zhoujinum >= 2)
            {
                int lastAct = 0;
                foreach (CastingSkill cs in BattleSystem.instance.EnemyCastSkills)
                {
                    if (cs.skill.Master == this.BChar && cs.CastSpeed > lastAct)
                    {
                        lastAct = cs.CastSpeed;
                    }
                }

                List<BattleChar> list = new List<BattleChar>();
                Skill skill = Skill.TempSkill("S_YoumuF_5", this.BChar, this.BChar.MyTeam);
                list.AddRange((this.BChar as BattleEnemy).Ai.TargetSelect(skill));
                BattleSystem.instance.EnemyCastEnqueue(this.BChar as BattleEnemy, skill, list, lastAct + 1, false);
            }
        }
    }
}