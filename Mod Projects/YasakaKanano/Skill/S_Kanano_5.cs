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
namespace YasakaKanano
{
	/// <summary>
	/// 神谷「Divining Crop」
	/// 获得 &a 防护墙<color=#00E5EE>(自身最大体力值的25%)</color>。
	/// <color=#CD5555>饥馑5</color> - 施加的[庆典之西风]的持续回合数+1。
	/// </summary>
    public class S_Kanano_5: Skillbase_Kanano
    {
        public override void Init()
        {
            base.Init();
            this.SkillParticleObject = new GDESkillExtendedData(GDEItemKeys.SkillExtended_Public_1_Ex).Particle_Path;
        }

        public int fixCount = 0;

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            fixCount++;
            if (fixCount >= 12)
            {
                fixCount = 0;
                if (CheckDeck2(5))
                {
                    base.SkillParticleOn();
                    this.NotCount = true;
                }
                else
                {
                    base.SkillParticleOff();
                    this.NotCount = false;
                }
            }
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            BattleSystem.instance.AllyTeam.partybarrier.BarrierHP += (int)(this.BChar.GetStat.maxhp * 0.25);

            if (CheckDeck2(5))
            {
                MySkill.MySkill.Effect_Target.Buffs.Clear();
                this.TargetBuff.Clear();

                foreach (BattleChar bc in Targets)
                {
                    bc.BuffAdd("B_Kanano_5", this.BChar, false, 0, false, 2);
                }
            }
        }

        public override string DescExtended(string desc)
        {
            return base.DescExtended(desc).Replace("&a", ((int)(this.BChar.GetStat.maxhp * 0.25f)).ToString());
        }
    }
}