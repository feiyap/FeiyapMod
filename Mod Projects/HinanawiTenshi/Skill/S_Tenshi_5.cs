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
	/// 要石「天空之灵石」
	/// 施加1个随机天气增益。
	/// 如果自己身上有天气增益，消耗1个天气增益，额外施加1个随机天气增益。
	/// <color=#97FFFF>天启1</color> - 额外施加1个随机天气增益。
	/// </summary>
    public class S_Tenshi_5: SkillBase_Tenshi
    {
        public override void FixedUpdate()
        {
            base.FixedUpdate();
            Fixed_count++;

            if (Fixed_count >= 12)
            {
                Fixed_count = 0;

                if (CheckKishi(1, true))
                {
                    base.SkillParticleOn();
                }
                else
                {
                    base.SkillParticleOff();
                }
            }
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);

            AddTenki(Targets[0], 1);

            if (CheckTenki(false))
            {
                AddTenki(Targets[0], 1);
            }

            if (CheckKishi(1, false))
            {
                AddTenki(Targets[0], 1);
            }
        }
    }
}