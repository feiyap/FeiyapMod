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
namespace KirisameMarisa
{
	/// <summary>
	/// 彗星「Blazing Star」
	/// 倒计时期间，自身处于无敌状态。
	/// 释放时，速度大于0时，每有1点速度，这个技能造成&a点额外伤害<color=#FF7A33>(攻击力的50%)</color>。
	/// </summary>
    public class S_KirisameMarisa_Rare_11:Skill_Extended, IP_SkillCastingStart
    {
        public int PlusDmg
        {
            get
            {
                if (BattleSystem.instance == null || BattleSystem.instance.BattleLogs == null || BattleSystem.instance.TurnNum <= 0)
                {
                    return 0;
                }

                int count = PlayData.PartySpeed;

                if (count < 0)
                {
                    count = 0;
                }

                return (int)((float)(this.BChar.GetStat.atk * 0.5 * count));
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
            return base.DescExtended(desc).Replace("&a", ((int)((float)(this.BChar.GetStat.atk * 0.5))).ToString());
        }

        public void SkillCasting(CastingSkill ThisSkill)
        {
            this.BChar.BuffAdd("B_KirisameMarisa_Rare_11", this.BChar);
        }
    }
}