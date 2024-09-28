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
namespace Ralmia
{
	/// <summary>
	/// 洛菈米娅
	/// Passive:
	/// 每个回合开始时，获得一张【突破音速】。
	/// </summary>
    public class P_Ralmia:Passive_Char, IP_PlayerTurn, IP_BattleStart_Ones
    {
        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
        }

        public void Turn()
        {
            this.tmpSkill = Skill.TempSkill("S_Ralmia_P", this.BChar, this.BChar.MyTeam);
            BattleSystem.instance.AllyTeam.Add(tmpSkill, true);
        }
        private Skill tmpSkill;


        public void BattleStart(BattleSystem Ins)
        {
            this.BChar.BuffAdd("B_Ralmia_P", this.BChar, false, 0, false, -1, false);
        }
    }
}