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
	/// 掉进兔子洞
	/// 这个技能释放后，到目标行动时将一张“掉进兔子洞”加入手牌中。
	/// 释放后的此技能倒计时减少时，给予目标(<sprite=2>85%)1层美梦。
	/// </summary>
    public class S_FVAlice_7:Skill_Extended, IP_SkillCastingStart, IP_SkillCastingQuit
    {
        private int castTime;
        private CastingSkill m_skill;

        public override void HandInit()
        {
            base.HandInit();
            this.castTime = 0;
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            if (BattleSystem.instance != null)
            {
                if (castTime != 0 && BattleSystem.instance.AllyTeam.TurnActionNum > castTime)
                {
                    castTime = BattleSystem.instance.AllyTeam.TurnActionNum;

                    BattleChar bc = m_skill.Target;
                    bc.BuffAdd("B_FVAlice_1", this.BChar, false, -25);
                }
            }
        }

        public void SkillCasting(CastingSkill ThisSkill)
        {
            castTime = BattleSystem.instance.AllyTeam.TurnActionNum;
            m_skill = ThisSkill;

            BattleChar bc = m_skill.Target;
            bc.BuffAdd("B_FVAlice_7", this.BChar);
        }

        public void SkillCastingQuit(CastingSkill ThisSkill)
        {
            BattleChar bc = m_skill.Target;
            bc.BuffReturn("B_FVAlice_7")?.SelfDestroy();
        }
    }
}