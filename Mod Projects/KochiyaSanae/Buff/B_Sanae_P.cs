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
namespace KochiyaSanae
{
	/// <summary>
	/// 被祭拜的风之人
	/// 当前连击数为：&a
	/// 距离恢复法力值还剩：&b
	/// </summary>
    public class B_Sanae_P:Buff
    {
        public override string DescExtended()
        {
            return base.DescExtended().Replace("&a", ((int)(BattleSystem.instance.BattleLogs.getSkills((BattleLog log) => log.WhoUse.Info.Ally, (Skill skill) => !skill.FreeUse, BattleSystem.instance.TurnNum).Count)).ToString())
                                      .Replace("&b", ((int)(4 - P_KochiyaSanae.UseNum)).ToString());
        }
    }
}