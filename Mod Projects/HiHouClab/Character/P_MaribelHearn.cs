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
using BasicMethods;
using System.Windows.Forms.VisualStyles;
namespace HiHouClab
{
    /// <summary>
    /// 玛艾露贝莉·赫恩
    /// Passive:
    /// 看得见结界的能力 - 玛艾露贝莉·赫恩的治疗技能处于倒计时期间时，指向的目标获得“保护体力极限”；并且目标在受到量子伤害时，会获得相同数值的保护罩。
    /// 少女秘封俱乐部 - 玛艾露贝莉·赫恩与宇佐见莲子同时在场时，战斗开始时从牌库抽取 1 个“伊奘诺物质”。
    /// </summary>
    public class P_MaribelHearn : Passive_Char, IP_SkillCastingStart_Team, IP_PlayerTurn
    {
        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
        }

        public void SkillCastingStart_Team(CastingSkill startCastingSkill)
        {
            if (startCastingSkill.skill.Master == this.BChar)
            {
                foreach (BattleChar bc in startCastingSkill.TargetReturn())
                {
                    if (bc.Info.Ally)
                    {
                        bc.BuffAdd("B_Maribel_P", this.BChar);
                    }
                }
            }
        }

        public void Turn()
        {
            if (BattleSystem.instance.AllyList.Any((BattleChar bc) => bc.Info.KeyData == "UsamiRenko") && BattleSystem.instance.AllyList.Any((BattleChar bc) => bc.Info.KeyData == "MaribelHearn"))
            {
                BattleSystem.instance.AllyTeam.WaitCount += 2;
            }
        }
    }
}