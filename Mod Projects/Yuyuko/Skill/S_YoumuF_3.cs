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
	/// 狱神剑「业风神闪斩」
	/// 随机追加3次行动（“狱神剑「业风神闪斩」”除外）。
	/// </summary>
    public class S_YoumuF_3:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            int lastAct = 0;
            foreach (CastingSkill cs in BattleSystem.instance.EnemyCastSkills)
            {
                if (cs.skill.Master == this.BChar && cs.CastSpeed > lastAct)
                {
                    lastAct = cs.CastSpeed;
                }
            }

            List<BattleChar> list1 = new List<BattleChar>();
            Skill skill1 = Skill.TempSkill("S_YoumuF_5", this.BChar, BChar.MyTeam);
            list1.AddRange((BChar as BattleEnemy).Ai.TargetSelect(skill1));
            BattleSystem.instance.EnemyCastEnqueue(BChar as BattleEnemy, skill1, list1, lastAct + 1, false);

            List<BattleChar> list2 = new List<BattleChar>();
            Skill skill2 = Skill.TempSkill("S_YoumuF_5", BChar, BChar.MyTeam);
            list2.AddRange((BChar as BattleEnemy).Ai.TargetSelect(skill2));
            BattleSystem.instance.EnemyCastEnqueue(BChar as BattleEnemy, skill2, list2, lastAct + 2, false);

            List<BattleChar> list3 = new List<BattleChar>();
            Skill skill3 = Skill.TempSkill("S_YoumuF_5", BChar, BChar.MyTeam);
            list3.AddRange((BChar as BattleEnemy).Ai.TargetSelect(skill3));
            BattleSystem.instance.EnemyCastEnqueue(BChar as BattleEnemy, skill3, list3, lastAct + 3, false);
        }
    }
}