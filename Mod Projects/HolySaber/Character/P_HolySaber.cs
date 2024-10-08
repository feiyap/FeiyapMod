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
namespace HolySaber
{
	/// <summary>
	/// 圣辉女剑士
	/// Passive:
	/// <b>进化</b> - 战斗开始时，获得3个进化点。固定能力变更为[进化]：消耗1个进化点，使手中1个技能触发[进化]效果。
	/// <b>圣女的号令</b> - 回合开始时，若<color=#FFC125>进化5</color>，将一张[圣女的号令]加入手中。这个效果1场战斗只能触发1次。
	/// <color=#FFC125><b>进化X</b></color> - 本场战斗中，已发动的[进化]的次数大于X次时，可以触发额外效果。
	/// <color=#4876FF><b>守护X</b></color> - 本场战斗中，已使用过带有[守护]减益的技能的次数大于X次时，可以触发额外效果。
	/// </summary>
    public class P_HolySaber:Passive_Char, IP_BattleStart_Ones, IP_PlayerTurn
    {
        public int count = 0;

        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
        }

        public void BattleStart(BattleSystem Ins)
        {
            count = 0;
            this.BChar.BuffAdd("B_HolySaber_P", this.BChar);
            this.BChar.BuffAdd("B_HolySaber_P", this.BChar);
            this.BChar.BuffAdd("B_HolySaber_P", this.BChar);
        }

        public void Turn()
        {
            if (CheckUsedExSkills(5) && count == 0)
            {
                Skill tmpSkill = Skill.TempSkill("S_HolySaber_P_0", this.BChar, this.BChar.MyTeam);
                BattleSystem.instance.AllyTeam.Add(tmpSkill, true);
                count++;
            }
        }

        public bool CheckUsedExSkills(int count)
        {
            return BattleSystem.instance.BattleLogs.getSkills((BattleLog log) => log.WhoUse.Info.Ally, (Skill skill) => !skill.FreeUse && skill.ExtendedFind_DataName("SE_HolySaber_Extended") != null, -1).Count >= count;
        }
    }
}