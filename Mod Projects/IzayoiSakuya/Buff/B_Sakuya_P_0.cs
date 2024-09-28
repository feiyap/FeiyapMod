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
namespace IzayoiSakuya
{
	/// <summary>
	/// 时钟停摆
	/// 每叠加5层，将1张[时计「月时计」]加入手中。
	/// </summary>
    public class B_Sakuya_P_0:Buff
    {
        public override void Init()
        {
            base.Init();
            if (base.StackNum % 4 == 0)
            {
                Skill tmpSkill = Skill.TempSkill("S_Sakuya_P", base.Usestate_L, base.Usestate_L.MyTeam);
                BattleSystem.instance.AllyTeam.Add(tmpSkill, true);
            }
        }
    }
}