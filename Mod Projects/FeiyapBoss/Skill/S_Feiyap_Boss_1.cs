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
namespace FeiyapBoss
{
	/// <summary>
	/// 里绯夜流·红光
	/// </summary>
    public class S_Feiyap_Boss_1:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);
            if (Targets[0].GetStat.Strength)
            {
                Targets[0].HP = 1;
            }
            else
            {
                Targets[0].BuffAdd("B_Feiyap_Boss_1", this.BChar);
            }
        }
    }
}