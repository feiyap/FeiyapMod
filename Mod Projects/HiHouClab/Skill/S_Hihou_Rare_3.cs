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
namespace HiHouClab
{
	/// <summary>
	/// <color=#7B68EE>七</color><color=#4169E1>夕</color><color=#2E8B57>坂</color><color=#FF6A6A>梦</color><color=#FF00FF>幻</color><color=#836FFF>能</color>
	/// <i><color=#FFD700>*日出七夕坂+不等式的廷克·贝尔*</color></i>
	/// 使<b><color=#7B68EE>玛艾露贝莉·赫恩</color></b>获得2回合的<b>无敌</b>状态。
	/// 使<color=#4169E1>宇佐见莲子</color>获得2回合的<b>隐匿</b>状态。
	/// <i>
	/// <color=#7B68EE>被隐匿的第五个季节在此出现</color>
	/// <color=#4169E1>完全失落的此世之姿在此复苏</color>
	/// <color=#FFD700>该国的禁忌，就此被打破了！</color>
	/// </i>
	/// </summary>
    public class S_Hihou_Rare_3:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);

            Planck.PlanckAP += 3;
            Debug.Log("SKILL");
            Debug.Log(this.MySkill.MySkill.Effect_Self.AP);
        }
    }
}