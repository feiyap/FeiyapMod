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
namespace HouraisanKaguya
{
	/// <summary>
	/// 神宝「火蜥蜴之盾」
	/// </summary>
    public class S_FKaguya_5:Skill_Extended
    {
        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
            this.SkillParticleObject = new GDESkillExtendedData(GDEItemKeys.SkillExtended_Priest_Ex_P).Particle_Path;
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();

            if (this.BChar.BuffFind("B_FKaguya_Sinnpou"))
            {
                base.SkillParticleOn();
            }
            else
            {
                base.SkillParticleOff();
            }
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);

            MySkill.MySkill.Effect_Target.Buffs.Clear();
            this.TargetBuff.Clear();

            for (int i = 0; i < Targets.Count; i++)
            {
                int count = 0;
                if (Targets[i].GetBuffs(BattleChar.GETBUFFTYPE.DOT, false, false).Count != 0)
                {
                    List<Buff> list = new List<Buff>();
                    foreach (Buff buff in Targets[i].Buffs)
                    {
                        if (buff.BuffData.Debuff && !buff.BuffData.Cantdisable && buff.BuffData.BuffTag.Key == GDEItemKeys.BuffTag_DOT && !buff.BuffData.Hide && !buff.DestroyBuff)
                        {
                            count += buff.StackNum;
                            buff.SelfDestroy();
                        }
                    }
                    if (!Targets[i].Info.Ally)
                    {
                        this.KaguyaAttack(Targets[i], count);
                    }
                }


                if (Targets[i].Info.Ally && this.BChar.BuffFind("B_FKaguya_Sinnpou"))
                {
                    Targets[i].BuffAdd("B_FKaguya_5", this.BChar, false, 0, false, 3, false);
                }
            }

            if (this.BChar.BuffFind("B_FKaguya_Sinnpou"))
            {
                this.BChar.BuffReturn("B_FKaguya_Sinnpou").SelfDestroy();
            }
        }

        public virtual void KaguyaAttack(BattleChar hit, int count)
        {
            for (int i = 0; i < count; i++)
            {
                Skill skill = Skill.TempSkill("S_FKaguya_5_0", this.BChar, this.BChar.MyTeam);
                skill.PlusHit = true;
                skill.MySkill.Effect_Target.DMG_Base = PlusDmg;
                BattleSystem.DelayInput(this.EirinAttack(skill, hit));
            }
        }

        public IEnumerator EirinAttack(Skill skill, BattleChar hit)
        {
            yield return new WaitForSecondsRealtime(0.1f);
            this.BChar.ParticleOut(skill, hit);
            yield return null;
            yield break;
        }

        public override string DescExtended(string desc)
        {
            return base.DescExtended(desc).Replace("&a", (this.PlusDmg).ToString());
        }

        public int PlusDmg
        {
            get
            {
                return (int)((float)(0 + this.BChar.GetStat.maxhp * 0.2));
            }
        }
    }
}