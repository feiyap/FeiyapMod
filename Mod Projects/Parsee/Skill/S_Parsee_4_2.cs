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
namespace Parsee
{
	/// <summary>
	/// 定期心理诊断
	/// 解除目标 1 个随机<sprite=2>干扰减益。
	/// </summary>
    public class S_Parsee_4_2:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);

            List<Buff> buffs = Targets[0].GetBuffs(BattleChar.GETBUFFTYPE.CC, true, false);
            if (buffs.Count != 0)
            {
                buffs.Random(this.BChar.GetRandomClass().Main).SelfDestroy(false);
            }
        }
    }
}