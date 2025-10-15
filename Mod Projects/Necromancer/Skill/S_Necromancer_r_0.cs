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
namespace Necromancer
{
	/// <summary>
	/// 怆痛涟漪
	/// 每次打出，费用翻倍。
	/// 当自身已拥有怆痛涟漪时，强化怆痛涟漪。
	/// lv1：取消额外扩散的限制。
	/// lv2：若目标唯一，扩散翻倍。
	/// lv3：扩散同时施加生命崩解。
	/// lv4：扩散同时施加灵压内爆。
	/// </summary>
    public class S_Necromancer_r_0:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);
			int nowAP = Mathf.Max(SkillD.AP, 1);
            for (int i = 0; i < nowAP; i++)
			{
				SkillD.ExtendedAdd_Battle("Extended_Necromancer_0_EX");
			}
        }
    }
}