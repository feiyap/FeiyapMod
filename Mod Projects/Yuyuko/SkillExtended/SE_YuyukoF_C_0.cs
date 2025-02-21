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
namespace Yuyuko
{
	/// <summary>
	/// <color=#4876FF>幽冥蝶</color> - 施加时，对随机调查员释放这个技能。
	/// <color=#FF69B4>人魂蝶</color> - 施加时，对随机调查员释放这个技能。
	/// 治疗技能
	/// </summary>
    public class SE_YuyukoF_C_0:Skill_Extended
    {
        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
        }
        
        public override bool CanSkillEnforce(Skill MainSkill)
        {
            return MainSkill.IsDamage && (MainSkill.MySkill.Target.Key == GDEItemKeys.s_targettype_all_onetarget || MainSkill.MySkill.Target.Key == GDEItemKeys.s_targettype_enemy || MainSkill.MySkill.Target.Key == GDEItemKeys.s_targettype_random_enemy);
        }
        
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            if (Targets[0].BuffFind("B_YuyukoF_Butterfly_M", false) && Targets[0].BuffFind("B_YuyukoF_Butterfly_R", false))
            {
                BattleSystem.instance.AllyTeam.AP++;
                BattleSystem.instance.AllyTeam.Draw();
            }
        }
    }
}