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
namespace Reisen
{
	/// <summary>
	/// 生药「国士无双之药」
	/// 获得2层[狂气]。使用4次后放逐。
	/// </summary>
    public class S_Reisen_12Rare:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            Targets[0].Heal(this.BChar, (int)(Targets[0].GetStat.maxhp * 0.5), false, false);
        }
    }
}