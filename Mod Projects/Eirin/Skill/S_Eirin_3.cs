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
namespace Eirin
{
	/// <summary>
	/// 操神「思兼装置」
	/// 改变目标的嘲讽状态。那之后，根据目标当前的嘲讽状态：
	/// 嘲讽 - 使目标获得[月人/月使]。
	/// 非嘲讽 - 使所有友军获得[月人/操神]。
	/// </summary>
    public class S_Eirin_3:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);

            MySkill.MySkill.Effect_Target.Buffs.Clear();
            this.TargetBuff.Clear();

            if (Targets[0] is BattleEnemy && (Targets[0] as BattleEnemy).istaunt)
            {
                Targets[0].BuffScriptReturn("Common_Buff_EnemyTaunt").SelfDestroy(false);
                for (int i = 0; i < BattleSystem.instance.AllyList.Count; i++)
                {
                    BattleSystem.instance.AllyList[i].BuffAdd("B_Eirin_3", this.BChar, false, 0, false, 2, false);
                }
                return;
            }
            Targets[0].BuffAdd(GDEItemKeys.Buff_B_EnemyTaunt, Targets[0], false, 0, false, -1, false);

            if (Targets[0].BuffFind(GDEItemKeys.Buff_B_EnemyTaunt))
            {
                Targets[0].BuffAdd("B_Eirin_3_0", this.BChar, false, 0, false, 6, false);
            }
        }
    }
}