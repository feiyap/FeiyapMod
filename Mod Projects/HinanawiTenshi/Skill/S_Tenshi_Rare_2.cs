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
namespace HinanawiTenshi
{
	/// <summary>
	/// 地震「先忧后乐之剑」
	/// (150%干扰)眩晕目标。
	/// <color=#97FFFF>天启9</color> - 触发时，改为眩晕所有敌人。
	/// </summary>
    public class S_Tenshi_Rare_2: SkillBase_Tenshi
    {
        public BattleChar saveTarget;

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            Fixed_count++;

            if (Fixed_count >= 12)
            {
                Fixed_count = 0;

                if (CheckKishi(9, true))
                {
                    base.SkillParticleOn();
                    this.MySkill.MySkill.Target = new GDEs_targettypeData(GDEItemKeys.s_targettype_all_enemy);
                }
                else
                {
                    base.SkillParticleOff();
                    this.MySkill.MySkill.Target = new GDEs_targettypeData(GDEItemKeys.s_targettype_enemy);
                }
            }
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            if (CheckKishi(9, false))
            {

            }
        }
    }
}