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
	/// 神宝「耀眼的龙玉」
	/// 神宝 - 超额恢复所有友军4体力。
	/// </summary>
    public class S_FKaguya_1:Skill_Extended
    {
        public override void Init()
        {
            base.Init();
            this.SkillParticleObject = new GDESkillExtendedData(GDEItemKeys.SkillExtended_Priest_Ex_P).Particle_Path;
        }

        public override string DescExtended(string desc)
        {
            return base.DescExtended(desc).Replace("&a", ((int)(this.BChar.GetStat.maxhp * 0.2)).ToString());
        }

        public override void SkillUseSingleAfter(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingleAfter(SkillD, Targets);

            BattleSystem.DelayInput(this.FireEffect());

            if (this.BChar.BuffFind("B_FKaguya_Sinnpou"))
            {
                foreach (BattleAlly battleAlly in BattleSystem.instance.AllyList)
                {
                    battleAlly.Heal(this.BChar, (int)(this.BChar.GetStat.maxhp * 0.2), this.BChar.GetCri(), true, null);
                }
                this.BChar.BuffReturn("B_FKaguya_Sinnpou").SelfDestroy();
            }
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

        public IEnumerator FireEffect()
        {
            foreach (BattleEnemy battleEnemy in BattleSystem.instance.EnemyList)
            {
                foreach (Buff buff in battleEnemy.GetBuffs(BattleChar.GETBUFFTYPE.DOT, false, false))
                {
                    foreach (StackBuff stackBuff in buff.StackInfo)
                    {
                        if (stackBuff.RemainTime != 0)
                        {
                            stackBuff.RemainTime++;
                        }
                    }
                }
                foreach (Buff buff2 in battleEnemy.GetBuffs(BattleChar.GETBUFFTYPE.DEBUFF, false, false))
                {
                    foreach (StackBuff stackBuff2 in buff2.StackInfo)
                    {
                        if (stackBuff2.RemainTime != 0)
                        {
                            stackBuff2.RemainTime++;
                        }
                    }
                }
            }
            yield return null;
            yield break;
        }
    }
}