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
    public class Saber_shanyao_ex: Skill_Extended, IP_BattleStart_Ones, IP_TurnEnd
    {
        public override void Init()
        {
            base.Init();
            this.SkillParticleObject = new GDESkillExtendedData(GDEItemKeys.SkillExtended_Public_1_Ex).Particle_Path;
        }
        public override void FixedUpdate()
        {
            base.FixedUpdate();
            this.checkCount++;
            bool flag = this.checkCount >= 12;
            if (flag)
            {
                this.checkCount = 0;
                bool flag2 = Ex_Saber_jiefang.Checkjinsheng(10, this.BChar);
                if (flag2)
                {
                    base.SkillParticleOn();
                    this.Flag = true;
                }
                else
                {
                    base.SkillParticleOff();
                }
            }

        }
        public override void BattleStartDeck(List<Skill> Skills_Deck)
        {
            Skills_Deck.Remove(this.MySkill);
            Skills_Deck.Insert(0, this.MySkill);
        }
        public override IEnumerator DrawAction()
        {
            BattleSystem.instance.AllyTeam.Draw();
            return base.DrawAction();
        }
        public void BattleStart(BattleSystem Ins)
        {
            foreach (Skill skill in Ins.AllyTeam.Skills_Deck)
            {
                if (skill.Master == this.BChar)
                {
                    if (skill.MySkill.Target.Key == GDEItemKeys.s_targettype_all_enemy || skill.MySkill.Target.Key == GDEItemKeys.s_targettype_enemy || skill.MySkill.Target.Key == GDEItemKeys.s_targettype_enemy_PlusRandom || skill.MySkill.Target.Key == GDEItemKeys.s_targettype_random_enemy)
                    {
                        skill.ExtendedAdd_Battle(Skill_Extended.DataToExtended(ModItemKeys.SkillExtended_Saber_shanyao_ex_enemy));
                    }
                    if (skill.MySkill.Target.Key == GDEItemKeys.s_targettype_ally || skill.MySkill.Target.Key == GDEItemKeys.s_targettype_otherally || skill.MySkill.Target.Key == GDEItemKeys.s_targettype_self)
                    {
                        skill.ExtendedAdd_Battle(Skill_Extended.DataToExtended(ModItemKeys.SkillExtended_Saber_shanyao_ex_ally));
                    }
                    if (skill.MySkill.Target.Key == GDEItemKeys.s_targettype_all_ally)
                    {
                        skill.ExtendedAdd_Battle(Skill_Extended.DataToExtended(ModItemKeys.SkillExtended_Saber_shanyao_ex_ally));
                    }
                }
            }
        }
        public override bool Terms()
        {
            return this.Flag;
        }
        public void TurnEnd()
        {
                this.Flag = false;             
        }
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);
            Ex_Saber_jiefang.Usejinsheng(10, this.BChar);
            Skill skill = Skill.TempSkill("Saber_shengqiang", this.BChar, null);
            BattleSystem.instance.AllyTeam.Add(skill, true);
        }
        public bool Flag;
        public int checkCount = 0;
    }
}
