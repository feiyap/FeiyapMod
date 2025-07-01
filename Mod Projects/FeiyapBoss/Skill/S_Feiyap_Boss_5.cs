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
	/// 无声星陨
	/// 立即恢复「上个回合中，自己受到过的最高的单次伤害值」的体力。
	/// </summary>
    public class S_Feiyap_Boss_5:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);

            this.BChar.Heal(this.BChar, B_Feiyap_Boss_P_1.hprecordlast, false, false, null);
        }
    }
}