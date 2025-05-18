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
namespace Feiyap
{
	/// <summary>
	/// 短休
	/// 移除自身所有过载。
	/// 每移除 1 层过载，恢复 1 点法力值。
	/// </summary>
    public class S_Feiyap_8:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);

            Targets[0].Recovery = Targets[0].GetStat.maxhp;

            this.BChar.MyTeam.AP += Targets[0].Overload;
            Targets[0].Overload = 0;
        }
    }
}