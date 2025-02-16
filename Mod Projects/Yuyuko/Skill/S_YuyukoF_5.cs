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
using BasicMethods;
namespace Yuyuko
{
	/// <summary>
	/// 蝶符「凤蝶纹的死枪」
	/// 唤魂4 - 使这个技能获得“追踪”、“致命”、“无视嘲讽”。
    /// 葬送 - 对随机敌人释放这个技能。
    /// 幽冥蝶 - 施加时，触发1次亡者召还2。
    /// 人魂蝶 - 回引时，抽取2个技能。
	/// </summary>
    public class S_YuyukoF_5:Skill_Extended, IP_SkillSelfExcept
    {
        public override void Init()
        {
            base.Init();
            this.SkillParticleObject = new GDESkillExtendedData(GDEItemKeys.SkillExtended_Public_1_Ex).Particle_Path;
        }

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
            int num = Targets[0].Info.OriginStat.maxhp * 25 / 100;

            num = Math.Min(num, (int)(this.BChar.GetStat.atk * 5));

            if (P_YuyukoF.CheckGhost(4, false))
            {
                BattleSystem.instance.GetBattleValue<BV_YuyukoF_P>().setDieList(Targets[0], num, this.BChar);
            }
        }

        public bool SelfExcept(SkillLocation skillLoaction)
        {
            BattleSystem.DelayInput(BattleSystem.instance.SkillRandomUseIenum(this.BChar, this.MySkill, false, true, false));
            return true;
        }
    }
}