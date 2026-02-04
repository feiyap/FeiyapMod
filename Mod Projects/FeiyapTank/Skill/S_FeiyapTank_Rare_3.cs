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
namespace FeiyapTank
{
	/// <summary>
	/// 雨与夜的舞者
	/// 恢复自己和目标的体力极限。
	/// </summary>
    public class S_FeiyapTank_Rare_3:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);

            int num = Targets[0].Recovery - Targets[0].HP;
            Targets[0].Heal(Targets[0], (float)num, false, false, null);

            int num2 = this.BChar.Recovery - this.BChar.HP;
            this.BChar.Heal(this.BChar, (float)num2, false, false, null);
        }
    }
}