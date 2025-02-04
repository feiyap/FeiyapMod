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
	/// 死蝶「华胥之永眠」
    /// 增加20返魂值。
    /// 华胥 - 若指向目标拥有冥魂蝶，以暴击形式命中；若指向目标拥有人魂蝶，不再拥有倒计时1。
    /// 唤魂5 - 以倒计时2重复释放1次。
    /// 幽冥蝶 - 受到的非痛苦伤害转化为降低等量的最大体力值。
    /// 人魂蝶 - 受到的痛苦伤害转化为降低等量的最大体力值。
	/// </summary>
    public class S_YuyukoF_1:Skill_Extended
    {
        public int Fixed_count = 0;

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            Fixed_count++;

            if (Fixed_count >= 12)
            {
                Fixed_count = 0;

                if (P_YuyukoF.CheckGhost(5, true))
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
            BattleSystem.instance.GetBattleValue<BV_YuyukoF_P>().setFanhun(20);

            if (P_YuyukoF.Yuyu == P_YuyukoF.YuyuState.State_Huaxu)
            {
                if (P_YuyukoF.CheckGhost(5, false))
                {
                    Skill skill = Skill.TempSkill("S_YuyukoF_1", this.BChar, this.BChar.MyTeam);
                    skill.Counting = 2;
                    this.BChar.ParticleOut(skill, Targets[0]);
                }
            }
        }
    }
}