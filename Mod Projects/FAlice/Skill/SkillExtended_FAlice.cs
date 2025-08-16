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
using System.Reflection;
using BasicMethods;
using System.Security.Cryptography;

namespace FAlice
{
    public class SkillExtended_FAlice : Skill_Extended, IP_SkillCastingStart
    {
        public override void Init()
        {
            base.Init();
            this.SkillParticleObject = new GDESkillExtendedData(GDEItemKeys.SkillExtended_Public_1_Ex).Particle_Path;
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);
            if (BattleSystem.instance.CastSkills.Any(s => s.skill.MySkill.KeyID == ModItemKeys.Skill_S_FAlice_Rare_3_0)
                && SkillD.MySkill.KeyID != ModItemKeys.Skill_S_FAlice_Rare_3_0)
            {
                this.GoliathEffect();
                return;
            }
            int dollMax = this.BChar.BuffFind(ModItemKeys.Buff_B_FAlice_Rare_1) ? (this.BChar.Info.LV * 2) : (this.BChar.Info.LV + 1);
            Debug.Log(dollMax);
            Debug.Log(BattleSystem.instance.CastSkills.FindAll(cs => cs.skill.ExtendedFind<SkillExtended_FAlice>() != null).Count);
            if (this.MySkill.TargetTypeKey == GDEItemKeys.s_targettype_Misc
                && BattleSystem.instance.CastSkills.FindAll(cs => cs.skill.ExtendedFind<SkillExtended_FAlice>() != null).Count < dollMax)
            {
                if (SkillD.IsNowCasting)
                {
                    SkillD.GetType()?.GetField("isCounting", BindingFlags.NonPublic | BindingFlags.Instance)?.SetValue(SkillD, false);
                }
                SkillD.Counting = 9999;
                BattleSystem.DelayInput(BattleSystem.instance.ForceAction(SkillD, null, false, false, true));
                BattleSystem.DelayInput(saveUsedSkill());
                IEnumerator saveUsedSkill()
                {
                    yield return new WaitForFixedUpdate();
                    this.saveSkill = this.FindAndRemoveSkill(BattleSystem.instance.AllyTeam.Skills_UsedDeck, SkillD.CharinfoSkilldata.Seed)
                                  ?? this.FindAndRemoveSkill(BattleSystem.instance.AllyTeam.Skills_Deck, SkillD.CharinfoSkilldata.Seed);
                }
            }
        }

        public void SkillCasting(CastingSkill ThisSkill)
        {
            this.TriggerCount = 0;
            this.PlusPerATK = 0;
            this.PlusPerREG = 0;
            this.PlusPerDEF = 0;
            this.PlusSkillPerStat.Damage = 0;
            this.PlusSkillPerStat.Heal = 0;
            if (ThisSkill.skill.Counting > 1000)
            {
                ThisSkill.CastSpeed = Math.Max(ThisSkill.skill.Counting, 9999) + BattleSystem.instance.AllyTeam.TurnActionNum;
                ThisSkill.skill.GetType()?.GetField("isCounting", BindingFlags.NonPublic | BindingFlags.Instance)?.SetValue(ThisSkill.skill, false);
                ThisSkill.skill.Counting = 0;
                ThisSkill.skill.UseCountSkill();
                BasicMethods.CustomMethods.CountingSkillNotUseTurnEnd(ThisSkill.skill);
                if (BattleSystem.instance.NowEndedTurn)
                {
                    BasicMethods.ModData.NoUseSkills_Ally.Add(ThisSkill);
                    BattleSystem.instance.CastSkills.Remove(ThisSkill);
                    BattleSystem.instance.SaveSkill.Remove(ThisSkill);
                }
            }
        }

        public void TriggerEffect(bool enhance)
        {
            if (enhance)
            {
                this.EnhancedEffect();
            }
            else if (this.TriggerCount >= 3)
            {
                this.EnhancedEffect();
                this.TriggerCount = 0;
            }
            else
            {
                this.NormalEffect();
                this.TriggerCount++;
            }
        }

        public virtual void NormalEffect()
        {

        }

        public virtual void EnhancedEffect()
        {

        }

        public void GoliathEffect()
        {
            BattleSystem.instance.AllyTeam.AP++;
            BattleSystem.instance.AllyTeam.Draw(1);
        }

        public void PlusPerNum(int atk, int reg, int def)
        {
            this.PlusPerATK += atk;
            this.PlusPerREG += reg;
            this.PlusPerDEF += def;
            this.PlusSkillPerStat.Damage = this.PlusPerATK;
            this.PlusSkillPerStat.Heal = this.PlusPerREG;
        }

        public void CastingWaste()
        {
            CastingSkill castingSkill = this.MySkill?.MyButton?.castskill;
            if (castingSkill != null)
            {
                BattleSystem.instance.ActWindow.CastingWaste(castingSkill);
                BattleSystem.instance.CastSkills.Remove(castingSkill);
                BattleSystem.instance.SaveSkill.Remove(castingSkill);
                if (this.saveSkill != null)
                {
                    BattleSystem.instance.AllyTeam.Skills_UsedDeck.Add(this.saveSkill);
                    this.saveSkill = null;
                }
            }
        }

        private Skill FindAndRemoveSkill(List<Skill> deck, int seed)
        {
            Skill skill = deck.Find(s => s.CharinfoSkilldata.Seed == seed);
            deck.Remove(skill);
            return skill;
        }

        private int _triggerCount;
        public int TriggerCount
        {
            get
            {
                return _triggerCount;
            }
            set
            {
                _triggerCount = value;
                if (_triggerCount >= 3)
                {
                    this.SkillParticleOn();
                }
                else
                {
                    this.SkillParticleOff();
                }
            }
        }

        public int PlusPerATK;
        public int PlusPerREG;
        public int PlusPerDEF;
        private Skill saveSkill;

        public static void ChooseDollAndEffect(Action<SkillExtended_FAlice> effect, string chooseDesc)
        {
            List<Skill> list = BattleSystem.instance.CastSkills
                    .FindAll(cs => cs.skill.ExtendedFind<SkillExtended_FAlice>() != null)
                    .Select(cs => cs.skill.CloneSkill(true, cs.skill.Master))
                    .ToList();
            if (list.Count > 0)
            {
                if (list.Count == 1)
                {
                    CastingSkill castingSkill = BattleSystem.instance.CastSkills.Find(cs => cs.skill.CharinfoSkilldata.Seed == list.First().CharinfoSkilldata.Seed);
                    SkillExtended_FAlice se = castingSkill?.skill?.ExtendedFind<SkillExtended_FAlice>();
                    if (se != null)
                    {
                        effect(se);
                    }
                }
                else
                {
                    BattleSystem.DelayInput(BattleSystem.I_OtherSkillSelect(list,
                        button =>
                        {
                            CastingSkill castingSkill = BattleSystem.instance.CastSkills.Find(cs => cs.skill.CharinfoSkilldata.Seed == button.Myskill.CharinfoSkilldata.Seed);
                            SkillExtended_FAlice se = castingSkill?.skill?.ExtendedFind<SkillExtended_FAlice>();
                            if (se != null)
                            {
                                effect(se);
                            }
                        }, chooseDesc, false, false, true, false, true));
                }
            }
        }
    }
}
