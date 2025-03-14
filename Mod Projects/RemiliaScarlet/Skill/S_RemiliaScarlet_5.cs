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
    public class S_RemiliaScarlet_5:Skill_Extended, IP_SkillCastingStart, IP_SkillCastingQuit
    {
        public int PlusDmg
        {
            get
            {
                if (BattleSystem.instance == null || BattleSystem.instance.BattleLogs == null || BattleSystem.instance.TurnNum <= 0)
                {
                    return 0;
                }
                return (int)((float)(0 + this.BChar.GetStat.maxhp * 1.0));
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
            foreach (BattleChar bc in BattleSystem.instance.AllyList)
            {
                bc.BuffAdd("B_RemiliaScarlet_5", this.BChar, true, 0, false, -1, false);
            }
        }

        public void SkillCastingQuit(CastingSkill ThisSkill)
        {
            foreach (BattleChar bc in BattleSystem.instance.AllyList)
            {
                bc.BuffReturn("B_RemiliaScarlet_5")?.SelfDestroy();
            }
        }

        public override void AttackEffectSingle(BattleChar hit, SkillParticle SP, int DMG, int Heal)
        {
            this.BChar.Heal(this.BChar, (float)((int)((float)DMG * 0.5f)), this.BChar.GetCri(), true, null);
        }
    }
}