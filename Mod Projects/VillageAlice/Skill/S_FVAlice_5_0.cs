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
	/// 潮汐失重
	/// 当“梦境失重”被给予[盐渍]时丢弃原技能，将一张“潮汐失重”加入手牌中。
	/// 这个技能不会被【童话】。
	/// 这个技能造成 1 次普通伤害，1 次痛苦伤害，1 次混乱伤害。
	/// </summary>
    public class S_FVAlice_5_0:Skill_Extended
    {
        public override void AttackEffectSingle(BattleChar hit, SkillParticle SP, int DMG, int Heal)
        {
            hit.ChaosDamage(this.BChar, (int)(this.BChar.GetStat.atk * 0.42), false);
            hit.Damage(this.BChar, (int)(this.BChar.GetStat.atk * 0.42), false, true);
        }
    }
}