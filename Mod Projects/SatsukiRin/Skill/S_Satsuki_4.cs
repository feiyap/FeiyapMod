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
namespace SatsukiRin
{
	/// <summary>
	/// 春之花「漫天流樱」
	/// </summary>
    public class S_Satsuki_4:Skill_Extended
    {
        public override void HandInit()
        {
            base.HandInit();
            this.SkillBasePlus.Target_BaseDMG = 0;
            this.PlusSkillPerStat.Heal = 0;
            this.IsDamage = true;
            this.SkillBasePlusPreview.Target_BaseDMG = (int)((double)this.BChar.GetStat.atk * 0.6);
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);
            this.IsDamage = false;
            this.SkillBasePlus.Target_BaseDMG = 0;
            this.PlusSkillPerStat.Heal = 0;

            BattleSystem.DelayInputAfter(this.Ienum(Targets[0]));

            if (!Targets[0].Info.Ally)
            {
                this.IsHeal = false;
                this.IsDamage = true;
                this.SkillBasePlus.Target_BaseDMG = (int)((double)this.BChar.GetStat.atk * 0.6);
                this.PlusSkillPerStat.Heal = -99999;
                this.SkillBasePlus.Target_BaseHeal = 0;
            }
        }

        public IEnumerator Ienum(BattleChar Targets)
        {
            if (Targets.Info.Ally)
            {
                Skill skill = Skill.TempSkill("S_Satsuki_4_0", this.BChar, this.BChar.MyTeam);
                skill.isExcept = true;
                skill.FreeUse = true;
                skill.PlusHit = true;
                skill.NoAttackTimeWait = true;
                this.BChar.ParticleOut(skill, BattleSystem.instance.EnemyTeam.AliveChars.Random(this.BChar.GetRandomClass().Main));
            }
            else
            {
                BattleChar battleChar = null;
                foreach (BattleChar battleChar2 in BattleSystem.instance.AllyTeam.AliveChars)
                {
                    if (battleChar == null)
                    {
                        battleChar = battleChar2;
                    }
                    else if (battleChar != null && battleChar.HP > battleChar2.HP)
                    {
                        battleChar = battleChar2;
                    }
                }
                if (battleChar != null)
                {
                    battleChar.Heal(this.BChar, (int)(this.BChar.GetStat.reg * 1.3f), false, false, null);
                }
            }
            

            yield return new WaitForSecondsRealtime(0.1f);
            yield break;
        }

        public override void AttackEffectSingle(BattleChar hit, SkillParticle SP, int DMG, int Heal)
        {
            if (!hit.Info.Ally)
            {
                if (hit.BuffFind("B_Satsuki_6", false))
                {
                    hit.BuffRemove("B_Satsuki_6", false);
                }
            }
            else
            {
                S_Satsuki_4.Buffremove(hit);
            }   
        }
        
        public static void Buffremove(BattleChar hit)
        {
            List<Buff> list = new List<Buff>();
            foreach (Buff buff in hit.Buffs)
            {
                if (buff.BuffData.Debuff && !buff.BuffData.Cantdisable && !buff.BuffData.Hide && !buff.DestroyBuff)
                {
                    list.Add(buff);
                }
            }
            if (list.Count != 0)
            {
                hit.BuffRemove(list.Random(hit.GetRandomClass().Main).BuffData.Key, false);
            }
        }

        public override string DescExtended(string desc)
        {
            return base.DescExtended(desc).Replace("%a", ((int)(this.BChar.GetStat.atk * 1.0)).ToString()).Replace("%b", ((int)(this.BChar.GetStat.reg * 1.3)).ToString());
        }
    }
}