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
	/// 符卡等级
	/// </summary>
    public class B_YoumuF_Spell2:Buff
    {
        public override void Init()
        {
            base.Init();
            if (this.StackNum >= 5)
            {
                SelfDestroy();

                int lastAct = 0;
                foreach (CastingSkill cs in BattleSystem.instance.EnemyCastSkills)
                {
                    if (cs.skill.Master == this.BChar && cs.CastSpeed > lastAct)
                    {
                        lastAct = cs.CastSpeed;
                    }
                }

                if (this.BChar.Info.KeyData == "Boss_Youmu")
                {
                    List<BattleChar> list = new List<BattleChar>();
                    Skill skill = Skill.TempSkill("S_YoumuF_6", this.BChar, this.BChar.MyTeam);
                    list.AddRange((this.BChar as BattleEnemy).Ai.TargetSelect(skill));
                    BattleSystem.instance.EnemyCastEnqueue(this.BChar as BattleEnemy, skill, list, lastAct + 1, false);
                }
                if (this.BChar.Info.KeyData == "Boss_Ghost_Youmu")
                {
                    List<BattleChar> list = new List<BattleChar>();
                    Skill skill = Skill.TempSkill("S_GhostF_2", this.BChar, this.BChar.MyTeam);
                    list.AddRange((this.BChar as BattleEnemy).Ai.TargetSelect(skill));
                    BattleSystem.instance.EnemyCastEnqueue(this.BChar as BattleEnemy, skill, list, lastAct + 1, false);
                }
            }
        }
    }
}