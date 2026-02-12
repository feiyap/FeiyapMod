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
namespace FeiyapTank
{
	/// <summary>
	/// 居合 - 优先抽取 1 个自己的技能。获得 1 层“错身”。
	/// </summary>
    public class SE_FeiyapTank_C_1:Skill_Extended, IP_DiscardBefore
    {
        public void DiscardBefore(bool Click, Skill skill, bool HandFullWaste)
        {
            if (!HandFullWaste && skill == this.MySkill && !this.MySkill.isExcept)
            {
                this.BChar.BuffAdd("B_FeiyapTank_2", this.BChar);
                BattleSystem.instance.AllyTeam.CharacterDraw(this.BChar);
            }
        }
    }
}