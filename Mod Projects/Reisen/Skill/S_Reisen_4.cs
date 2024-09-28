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
	/// 弱心「丧心丧意(Demotivation)」
	/// 获得1层[狂气]。施加[幻象/丧心]。
	/// 幻象/狂气 - 额外施加[幻象/疮痍]。
	/// </summary>
    public class S_Reisen_4:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            MySkill.MySkill.Effect_Target.Buffs.Clear();
            this.TargetBuff.Clear();

            Targets[0].BuffAdd("B_Reisen_4", this.BChar, false, 0, false, -1, false);

            if (this.BChar.BuffFind("B_Reisen_P", false) || this.BChar.BuffFind("B_Reisen_6", false))
            {
                Targets[0].BuffAdd("B_Reisen_4_0", this.BChar, false, 0, false, -1, false);
            }
        }
    }
}