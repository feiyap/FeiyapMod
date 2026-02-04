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
	/// 哭血
	/// 居合 - 对所有敌人施加<sprite=1><color=purple>哭血</color>。
	/// </summary>
    public class S_FeiyapTank_4:Skill_Extended, IP_Discard
    {
        public void Discard(bool Click, Skill skill, bool HandFullWaste)
        {
            if (!HandFullWaste && skill == this.MySkill)
            {
                foreach (BattleChar be in BattleSystem.instance.EnemyList)
                {
                    be.BuffAdd("B_FeiyapTank_4", this.BChar);
                }
            }
        }
    }
}