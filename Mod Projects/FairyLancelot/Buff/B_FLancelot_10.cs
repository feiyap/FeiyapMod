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
namespace FairyLancelot
{
	/// <summary>
	/// 阿尔比昂的遗骸
	/// 使用技能时，依据技能的指向：
	/// 指向敌人 - 对其他敌人造成该技能40%的伤害。
	/// 所有敌人 - 额外施加持续 3 回合的“每次行动时受到 2% 最大体力值的伤害”。
	/// 自身 - 额外施加“防御力+2”，并恢复 1 点法力值。
	/// </summary>
    public class B_FLancelot_10:Buff, IP_SkillUse_Team_Target
    {
        public void SkillUseTeam_Target(Skill skill, List<BattleChar> Targets)
        {
            if (this.BChar != null && Targets != null)
            {
                if (skill.Master == this.BChar)
                {
                    if (skill.MySkill.Target.Key == GDEItemKeys.s_targettype_enemy)
                    {
                        foreach (BattleChar bc in BattleSystem.instance.EnemyList)
                        {
                            if (bc != Targets[0])
                            {
                                bc.Damage(this.BChar, (int)(skill.MySkill.Effect_Target.DMG_Per * this.BChar.GetStat.atk / 100 * 40 / 100), false);
                            }
                        }
                    }

                    if (skill.MySkill.Target.Key == GDEItemKeys.s_targettype_all_enemy)
                    {
                        foreach (BattleChar bc in Targets)
                        {
                            bc.BuffAdd("B_FLancelot_10_0", this.BChar);
                        }
                    }

                    if (skill.MySkill.Target.Key == GDEItemKeys.s_targettype_self)
                    {
                        Targets[0].BuffAdd("B_FLancelot_10_1", this.BChar);
                        this.BChar.MyTeam.AP++;
                    }
                }
            }
        }
    }
}