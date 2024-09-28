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
namespace Lumiore
{
	/// <summary>
	/// 璐米欧儿
	/// Passive:
	/// 战斗开始时，获得1点最大法力值。如果觉醒（最大法力值超过7点），部分卡片会有额外效果。
	/// 觉醒：战斗开始时，额外抽取1张技能。
	/// </summary>
    public class P_Lumiore:Passive_Char, IP_Discard, IP_BattleStart_Ones
    {
        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
        }

        public void BattleStart(BattleSystem Ins)
        {
            BattleSystem.instance.AllyTeam.LucyChar.BuffAdd("B_Lumiore_5", BattleSystem.instance.AllyTeam.LucyChar, false, 0, false, -1, false);
            if (this.BChar.MyTeam.MAXAP >= 7)
            {
                BattleSystem.instance.AllyTeam.Draw();
            }
        }

        public void Discard(bool Click, Skill skill, bool HandFullWaste)
        {
            this.BChar.BuffAdd("B_Lumiore_P", this.BChar, false, 0, false, -1, false);
        }
    }
}