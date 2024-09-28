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
namespace Inaba
{
	/// <summary>
	/// 冬日温泉一日游大奖！
	/// 消除所有友军的过载，获得2法力值。
	/// </summary>
    public class S_Inaba_P_6:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);

            this.BChar.MyTeam.AP += 2;
            foreach (BattleChar battleChar in this.BChar.MyTeam.AliveChars)
            {
                battleChar.Overload = 0;
            }
            BattleSystem.instance.AllyTeam.LucyChar.Overload = 0;
        }
    }
}