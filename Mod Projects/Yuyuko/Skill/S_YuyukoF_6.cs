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
	/// 樱符「完全墨染的樱花」
	/// 增加20返魂值。
	/// 唤魂4 - 亡者召还0。
	/// 华胥 - 改为减少20返魂值。
	/// 幽冥蝶 - 回引时，在手中生成1个“樱符「完全墨染的樱花」”。
	/// 人魂蝶 - 回引时，在手中生成1个“樱符「完全墨染的樱花」”。
	/// </summary>
    public class S_YuyukoF_6:Skill_Extended
    {
        public int Fixed_count = 0;

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            Fixed_count++;

            if (Fixed_count >= 12)
            {
                Fixed_count = 0;

                if (P_YuyukoF.CheckGhost(4, true))
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
            if (P_YuyukoF.Yuyu == P_YuyukoF.YuyuState.State_Huaxu)
            {
                BattleSystem.instance.GetBattleValue<BV_YuyukoF_P>().setFanhun(-20);
            }
            else
            {
                BattleSystem.instance.GetBattleValue<BV_YuyukoF_P>().setFanhun(20);
            }

            if (P_YuyukoF.CheckGhost(4, false))
            {
                P_YuyukoF.DeadRevive(this.BChar, 0);
            }
        }
    }
}