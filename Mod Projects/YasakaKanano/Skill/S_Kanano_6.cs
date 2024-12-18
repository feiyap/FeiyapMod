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
	/// 贽符「御射山御狩神事」
	/// 抽取1个技能。
	/// 当目标体力值不足50%时，将目标体力值变为0点。若目标为Boss，则改为生成3个[西风灵]。
	/// <color=#CD5555>饥馑5</color> - 改为体力值不足100%时才会触发此效果。
	/// </summary>
    public class S_Kanano_6: Skillbase_Kanano
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

        public override void Special_PointerEnter(BattleChar Char)
        {
            if (Char is BattleEnemy && Char.Info.EnemyCate != GDEItemKeys.EnemyCategory_ECategory_TrialEnemy)
            {
                if (!(Char as BattleEnemy).Boss)
                {
                    if (CheckDeck2(5))
                    {
                        if (100f >= Misc.NumToPer((float)Char.GetStat.maxhp, (float)Char.HP))
                        {
                            EffectView.TextOutSimple(Char, ScriptLocalization.CharText_Ilya.Kill);
                        }
                    }
                    else
                    {
                        if (50f >= Misc.NumToPer((float)Char.GetStat.maxhp, (float)Char.HP))
                        {
                            EffectView.TextOutSimple(Char, ScriptLocalization.CharText_Ilya.Kill);
                        }
                    }
                }
            }
            base.Special_PointerEnter(Char);
        }

        public int DamageChange(Skill SkillD, BattleChar Target, int Damage, ref bool Cri, bool View)
        {
            if (View)
            {
                return Damage;
            }
            if (Target is BattleEnemy && Target.Info.EnemyCate != GDEItemKeys.EnemyCategory_ECategory_TrialEnemy)
            {
                if ((Target as BattleEnemy).Boss)
                {
                    Skill tmpSkill = Skill.TempSkill("S_Kanano_P", this.BChar, this.BChar.MyTeam);
                    BattleSystem.instance.AllyTeam.Add(tmpSkill, true);
                    Skill tmpSkill2 = Skill.TempSkill("S_Kanano_P", this.BChar, this.BChar.MyTeam);
                    BattleSystem.instance.AllyTeam.Add(tmpSkill2, true);
                    Skill tmpSkill3 = Skill.TempSkill("S_Kanano_P", this.BChar, this.BChar.MyTeam);
                    BattleSystem.instance.AllyTeam.Add(tmpSkill3, true);
                }
                else 
                {
                    if (CheckDeck2(5))
                    {
                        if (100f >= Misc.NumToPer((float)Target.GetStat.maxhp, (float)Target.HP))
                        {
                            Target.HPToZero();
                            return 0;
                        }
                    }
                    else
                    {
                        if (50f >= Misc.NumToPer((float)Target.GetStat.maxhp, (float)Target.HP))
                        {
                            Target.HPToZero();
                            return 0;
                        }
                    }
                }
            }
            return Damage;
        }
    }
}