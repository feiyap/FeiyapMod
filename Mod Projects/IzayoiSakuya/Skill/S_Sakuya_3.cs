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
namespace IzayoiSakuya
{
	/// <summary>
	/// 幻在「钟表的残骸」
	/// 每经过1个倒计时，这个技能的伤害降低&a点<color=#FF7A33>(攻击力的50%)</color>。
    /// <color=#4169E1>月魔术</color> - 变为倒计时8。
	/// </summary>
    public class S_Sakuya_3: SkillExtended_Sakuya, IP_SkillCastingStart
    {
        private int plus_damage;
        private int castTime;

        public override void HandInit()
        {
            base.HandInit();
            this.plus_damage = 0;
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            if (BattleSystem.instance != null && BattleSystem.instance.AllyTeam.Skills.Count != 0)
            {
                this.Counting = 0;

                if (CheckLunaMagic())
                {
                    this.Counting = -2;
                }
            }

            plus_damage = (castTime - BattleSystem.instance.AllyTeam.TurnActionNum) * (int)(this.BChar.GetStat.atk * 0.5f);
            this.SkillBasePlus.Target_BaseDMG = this.plus_damage;
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            this.SkillBasePlus.Target_BaseDMG = this.plus_damage;
        }

        public void SkillCasting(CastingSkill ThisSkill)
        {
            castTime = BattleSystem.instance.AllyTeam.TurnActionNum;
        }

        public override string DescExtended(string desc)
        {
            return base.DescExtended(desc).Replace("&a", ((int)(this.BChar.GetStat.atk * 0.5f)).ToString());
        }
    }
}