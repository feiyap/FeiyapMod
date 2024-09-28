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
namespace saber
{
    public class Saber_lianzhan_ex:Skill_Extended
    {
        public override void FixedUpdate()
        {
            base.FixedUpdate();
            this.checkCount++;
            bool flag = this.checkCount >= 12;
            if (flag)
            {
                this.checkCount = 0;
                bool flag2 = Ex_Saber_jiefang.Checkmoli(4, this.BChar);
                if (flag2)
                {
                    base.SkillParticleOn();
                }
                else
                {
                    base.SkillParticleOff();
                }
                bool flag3 = Ex_Saber_jiefang.Checkmoli(4, this.BChar);
                if (flag3)
                {
                    this.APChange = -99;
                }
                bool flag4 = Ex_Saber_jiefang.Checkjianshi(1, this.BChar);
                if (flag4)
                {
                    base.SkillParticleOn();
                }
                bool flag5 = Ex_Saber_jiefang.Checkjiejie(1, this.BChar);
                if (flag5)
                {
                    base.SkillParticleOn();
                }
                bool flag6 = Ex_Saber_jiefang.Checkjiejie1(1, this.BChar);
                if (flag6)
                {
                    base.SkillParticleOn();
                }
            }

        }
        public override void Init()
        {
            base.Init();
            this.SkillParticleObject = new GDESkillExtendedData(GDEItemKeys.SkillExtended_Public_1_Ex).Particle_Path;
            base.Init();
            this.illusionSkill.Init(new GDESkillData(ModItemKeys.Skill_Saber_lianzhan_plus), this.BChar, this.BChar.MyTeam);
            this.illusionSkill.PlusHit = true;
        }
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);
            bool flag = Ex_Saber_jiefang.Checkjiejie(1, this.BChar);
            if (flag)
            {
                BattleSystem.instance.AllyTeam.AP++;
                BattleSystem.DelayInput(this.Draw());
            }
            bool flag2 = Ex_Saber_jiefang.Checkjianshi(1, this.BChar);
            if (flag2)
            {
                Ex_Saber_jiefang.Usejianshi(1, this.BChar);
                int num = 0;
                foreach (BattleChar battleChar in BattleSystem.instance.Targets)
                {
                    bool flag6 = battleChar.BuffFind("Saber_fengshi", false);
                    if (flag6)
                    {
                        num = battleChar.BuffReturn("Saber_fengshi", false).StackNum;
                    }
                }
                BattleSystem.DelayInput(this.Effect(Targets[0], num));
            }
            bool flag3 = Ex_Saber_jiefang.Checkjiejie1(1, this.BChar);
            if (flag3)
            {
                BattleSystem.instance.AllyTeam.AP++;
                BattleSystem.DelayInput(this.Draw());
            }
            bool flag4 = Ex_Saber_jiefang.Checkmoli(4, this.BChar);
            if (flag4)
            {
                BattleSystem.instance.AllyTeam.AP++;
                Ex_Saber_jiefang.Usemoli(4, this.BChar);
            }
            bool flag5 = Ex_Saber_jiefang.Checkmoli0(1, this.BChar);
            if (flag5)
            {
                BattleSystem.instance.AllyTeam.AP++;
                BuffTag buffTag = new BuffTag();
                buffTag.User = this.BChar;
                buffTag.BuffData = new GDEBuffData("Saber_moli");
                this.SelfBuff.Add(buffTag);
            }

        }
        public IEnumerator Draw()
        {
            bool flag = !this.MySkill.isExcept;
            if (flag)
            {
                bool flag2 = BattleSystem.instance.AllyTeam.Skills.Find((Skill a) => a.CharinfoSkilldata == this.MySkill.CharinfoSkilldata) == null;
                if (flag2)
                {
                    yield return BattleSystem.instance.StartCoroutine(BattleSystem.instance.AllyTeam._ForceDrawList(this.MySkill.CharinfoSkilldata, null));
                }
            }
            else
            {
                bool flag3 = BattleSystem.instance.AllyTeam.Skills_UsedDeck.Find((Skill a) => a.CharinfoSkilldata == this.MySkill.CharinfoSkilldata) != null;
                if (flag3)
                {
                    BattleSystem.instance.AllyTeam.Skills_UsedDeck.Remove(BattleSystem.instance.AllyTeam.Skills_UsedDeck.Find((Skill a) => a.CharinfoSkilldata == this.MySkill.CharinfoSkilldata));
                }
                else
                {
                    bool flag4 = BattleSystem.instance.AllyTeam.Skills_Deck.Find((Skill a) => a.CharinfoSkilldata == this.MySkill.CharinfoSkilldata) != null;
                    if (flag4)
                    {
                        BattleSystem.instance.AllyTeam.Skills_Deck.Remove(BattleSystem.instance.AllyTeam.Skills_Deck.Find((Skill a) => a.CharinfoSkilldata == this.MySkill.CharinfoSkilldata));
                    }
                }
            }
            yield return null;
            yield break;
        }
        public IEnumerator Effect(BattleChar Target, int Count)
        {
            yield return new WaitForSeconds(0.1f);
            int num;
            for (int i = 0; i < Count; i = num + 1)
            {
                if (BattleSystem.instance.EnemyTeam.AliveChar_GetInstance().Count != 0)
                {
                    Skill skill = Skill.TempSkill(ModItemKeys.Skill_Saber_lianzhan_plus, this.BChar, this.BChar.MyTeam);
                    skill.PlusHit = true;
                    if (Target.IsDead && BattleSystem.instance.EnemyTeam.AliveChars.Count != 0)
                    {
                        this.BChar.ParticleOut(this.MySkill, skill, BattleSystem.instance.EnemyTeam.AliveChars.Random(this.BChar.GetRandomClass().Main));
                    }
                    else
                    {
                        this.BChar.ParticleOut(this.MySkill, skill, Target);
                    }
                }
                yield return new WaitForSeconds(0.07f);
                num = i;
            }
            yield break;
        }
        public override string DescExtended(string desc)
        {
            return base.DescExtended(desc).Replace("&a", this.illusionSkill.TargetDamage.ToString());
        }
        private Skill illusionSkill = new Skill();
        public int checkCount = 0;
    }
}