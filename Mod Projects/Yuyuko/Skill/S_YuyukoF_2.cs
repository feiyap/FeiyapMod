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
	/// 幽雅「通向黄泉的诱蛾灯」
	/// 仅能指定同时拥有幽冥蝶和人魂蝶的敌人。
	/// 回引目标的幽冥蝶和人魂蝶。
	/// 唤魂30 - 额外造成&a(300%)伤害。
	/// 华胥 - 额外造成&a(300%)伤害。
	/// 幽冥蝶 - 施加时，触发一次亡者召还1。回引时，触发一次亡者召还1。
	/// 人魂蝶 - 施加时，获得8点亡魂。回引时，获得8点亡魂。
	/// </summary>
    public class S_YuyukoF_2:Skill_Extended
    {
        public override bool TargetSelectExcept(BattleChar ExceptTarget)
        {
            if (ExceptTarget.BuffFind("B_YuyukoF_Butterfly_M") && ExceptTarget.BuffFind("B_YuyukoF_Butterfly_R"))
            {
                return false;
            }
            return true;
        }

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

                this.SkillBasePlus.Target_BaseDMG = 0;

                if (P_YuyukoF.Yuyu == P_YuyukoF.YuyuState.State_Huaxu)
                {
                    this.SkillBasePlus.Target_BaseDMG += (int)(this.BChar.GetStat.atk * 4f);
                }

                if (P_YuyukoF.CheckGhost(10, true))
                {
                    base.SkillParticleOn();
                    this.SkillBasePlus.Target_BaseDMG += (int)(this.BChar.GetStat.atk * 4f);
                }
                else
                {
                    base.SkillParticleOff();
                }
            }
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            this.SkillBasePlus.Target_BaseDMG = 0;

            if (P_YuyukoF.Yuyu == P_YuyukoF.YuyuState.State_Huaxu)
            {
                this.SkillBasePlus.Target_BaseDMG += (int)(this.BChar.GetStat.atk * 4f);
            }

            if (P_YuyukoF.CheckGhost(10, false))
            {
                this.SkillBasePlus.Target_BaseDMG += (int)(this.BChar.GetStat.atk * 4f);
            }

            P_YuyukoF.ReturnAllButterfly();
        }

        public override string DescExtended(string desc)
        {
            return base.DescExtended(desc).Replace("&a", ((int)(this.BChar.GetStat.atk * 4f)).ToString());
        }
    }
}