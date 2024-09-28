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
namespace Kirito
{
	/// <summary>
	/// 冻伤
	/// </summary>
    public class B_Eugeo_P_0_0:Buff
    {
        public override void Init()
        {
            base.Init();
            if (base.StackNum >= 7)
            {
                base.SelfDestroy(false);
                Skill tmpSkill = Skill.TempSkill("S_Eugeo_0", base.Usestate_L, base.Usestate_L.MyTeam);
                BattleSystem.instance.AllyTeam.Add(tmpSkill, true);
            }
        }
    }
}