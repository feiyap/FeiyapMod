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
namespace Ralmia
{
	/// <summary>
	/// 守御的创造物
	/// 秒杀非精英和BOSS单位。
	/// </summary>
    public class S_Ralmia_9_1:Skill_Extended, IP_DamageChange
    {
        public override void Special_PointerEnter(BattleChar Char)
        {
            if (Char is BattleEnemy && !this.Except_Enemy.Contains(Char.Info.KeyData))
            {
                if ((Char as BattleEnemy).Boss)
                {
                    
                }
                else
                {
                    EffectView.TextOutSimple(Char, ScriptLocalization.CharText_Ilya.Kill);
                }
            }
            base.Special_PointerEnter(Char);
        }

        public override void AttackEffectSingle(BattleChar hit, SkillParticle SP, int DMG, int Heal)
        {
        }

        public int DamageChange(Skill SkillD, BattleChar Target, int Damage, ref bool Cri, bool View)
        {
            if (View)
            {
                return Damage;
            }
            if (Target is BattleEnemy && !this.Except_Enemy.Contains(Target.Info.KeyData))
            {
                if ((Target as BattleEnemy).Boss)
                {
                   
                }
                else
                {
                    Target.HPToZero();
                    return 0;
                }
            }
            return Damage;
        }

        public List<string> Except_Enemy = new List<string>
        {
            GDEItemKeys.Enemy_TrialofStrength_Enemy,
            GDEItemKeys.Enemy_TrialofBrave_Enemy1,
            GDEItemKeys.Enemy_TutorialSandbag_2,
            GDEItemKeys.Enemy_TutorialSandbag
        };

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);
            if (this.BChar.BuffFind("B_Ralmia_0", false))
            {
                BattleSystem.instance.AllyTeam.Draw();
                BattleTeam allyTeam = BattleSystem.instance.AllyTeam;
                int ap = allyTeam.AP;
                allyTeam.AP = ap + 1;
            }

            if (this.BChar.BuffFind("B_Ralmia_1", false))
            {
                BattleTeam allyTeam = BattleSystem.instance.AllyTeam;
                int ap = allyTeam.AP;
                allyTeam.AP = ap + 1;
            }
        }
    }
}