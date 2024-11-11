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
namespace RemiliaScarlet
{
	/// <summary>
	/// 恶魔「Remilia Stretch」
	/// 依据自身最大体力值，额外造成%a伤害。
	/// </summary>
    public class S_RemiliaScarlet_5:Skill_Extended, IP_SkillCastingStart
    {
        public int PlusDmg
        {
            get
            {
                if (BattleSystem.instance == null || BattleSystem.instance.BattleLogs == null || BattleSystem.instance.TurnNum <= 0)
                {
                    return 0;
                }
                return (int)((float)(0 + this.BChar.GetStat.maxhp * 0.5));
            }
        }

        public override void Init()
        {
            base.Init();
            this.SkillBasePlus.Target_BaseDMG = this.PlusDmg;
            this.CountingExtedned = true;
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            this.SkillBasePlus.Target_BaseDMG = this.PlusDmg;
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);
            this.SkillBasePlus.Target_BaseDMG = this.PlusDmg;
        }

        public override string DescExtended(string desc)
        {
            return base.DescExtended(desc).Replace("&a", (this.PlusDmg).ToString());
        }
        
        public void SkillCasting(CastingSkill ThisSkill)
        {
            this.BChar.BuffAdd("B_RemiliaScarlet_4", this.BChar, false, 0, false, -1, false);
        }

        public override void AttackEffectSingle(BattleChar hit, SkillParticle SP, int DMG, int Heal)
        {
            this.BChar.Heal(this.BChar, (float)((int)((float)DMG * 1.0f)), this.BChar.GetCri(), true, null);
        }
    }
}