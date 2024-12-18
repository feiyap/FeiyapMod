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
	/// 御柱「流星般的御柱」
	/// <color=#CD5555>饥馑10</color> - 这个技能造成伤害的100%连锁治疗自己。
	/// </summary>
    public class S_Kanano_2: Skillbase_Kanano
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
                if (CheckDeck2(10))
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
            MySkill.MySkill.Effect_Self.Buffs.Clear();
            this.SelfBuff.Clear();

            BattleSystem.instance.GetBattleValue<BV_Kanano_P>().addYuzhuBuff("B_Kanano_2", this.BChar);
        }

        public override void AttackEffectSingle(BattleChar hit, SkillParticle SP, int DMG, int Heal)
        {
            if (CheckDeck2(10))
            {
                this.BChar.Heal(this.BChar, (int)DMG, this.BChar.GetCri(), false, new BattleChar.ChineHeal());
            }
        }
    }
}