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
namespace VillageAlice
{
	/// <summary>
	/// 掉进兔子洞
	/// </summary>
    public class B_FVAlice_7:Buff
    {
        public override void TurnUpdate()
        {
            base.TurnUpdate();

            Skill tmpSkill = Skill.TempSkill("S_FVAlice_7", this.Usestate_F, this.Usestate_F.MyTeam);
            //tmpSkill.isExcept = true;
            BattleSystem.instance.AllyTeam.Add(tmpSkill, true);
            this.SelfDestroy();
        }
    }
}