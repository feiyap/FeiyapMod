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
namespace FAlice
{
    /// <summary>
    /// 爱丽丝
    /// Passive:
    /// 操控人偶程度的能力 - 爱丽丝的「人形」技能在使用后会以倒计时∞的形式加入倒计时栏中。这些技能不会因回合结束而释放。
    /// 场上最多只能存在“等同于爱丽丝等级”数量的「人形」技能。
    /// 布加勒斯特的人偶师 - 每个回合开始时，生成 1 个费用为 1 的“操符「操纵人形」”，附带放逐和 1 回合后弃牌。
    /// </summary>
    public class P_FAlice : Passive_Char, IP_PlayerTurn
    {
        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
        }

        public void Turn()
        {
            Skill skill = Skill.TempSkill(ModItemKeys.Skill_S_FAlice_0, this.BChar, this.BChar.MyTeam);
            skill.AP = 1;
            skill.isExcept = true;
            skill.AutoDelete = 1;
            BattleSystem.instance.AllyTeam.Add(skill, true);
        }

        public static List<string> Dolls = new List<string>
        {
            ModItemKeys.Skill_S_FAlice_1,
            ModItemKeys.Skill_S_FAlice_2,
            ModItemKeys.Skill_S_FAlice_3,
            ModItemKeys.Skill_S_FAlice_4,
            ModItemKeys.Skill_S_FAlice_5
        };
    }
}