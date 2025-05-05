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
namespace VillageAlice
{
	/// <summary>
	/// 焦糖味封蜡
	/// 将目标拥有的所有弱化、痛苦减益给予“每层弱化/痛苦减益，每回合造成30%+1的混乱伤害。”
	/// 【童话】：此技能法力值消耗增加2。
	/// </summary>
    public class S_FVAlice_2:Skill_Extended
    {
        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
            this.SkillParticleObject = new GDESkillExtendedData(GDEItemKeys.SkillExtended_Priest_Ex_P).Particle_Path;
        }

        public int buffCount_L = 0;
        public int buffCount_N = 0;
        public int Fixed_count = 0;

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            Fixed_count++;

            if (Fixed_count >= 12)
            {
                Fixed_count = 0;

                if (this.MySkill.ExtendedFind_DataName("SkillExtended_Fairytale") != null)
                {
                    base.SkillParticleOn();
                    this.APChange = 2;
                }
                else
                {
                    base.SkillParticleOff();
                    this.APChange = 0;
                }
            }
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            foreach (Buff buff in Targets[0].GetBuffs(BattleChar.GETBUFFTYPE.DEBUFF, false))
            {
                if (buff.BuffExtended.Find((Buff_Ex a) => a.BuffExKey == "B_FVAlice_2_BuffEx") == null)
                {
                    buff.AddBuffEx(new B_FVAlice_2_BuffEx());
                }
            }
            foreach (Buff buff in Targets[0].GetBuffs(BattleChar.GETBUFFTYPE.DOT, false))
            {
                if (buff.BuffExtended.Find((Buff_Ex a) => a.BuffExKey == "B_FVAlice_2_BuffEx") == null)
                {
                    buff.AddBuffEx(new B_FVAlice_2_BuffEx());
                }
            }
        }

        public override string DescExtended(string desc)
        {
            return base.DescExtended(desc).Replace("&a", ((int)(this.BChar.GetStat.atk * 0.3f + 1)).ToString());
        }
    }
}