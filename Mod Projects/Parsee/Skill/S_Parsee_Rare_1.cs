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
namespace Parsee
{
	/// <summary>
	/// 恨符「丑时参拜第七日」
	/// 造成[700%治疗力]点痛苦伤害。该痛苦伤害无法击杀敌人。
	/// 本回合累计获得14层及以上的妒火时，改为指向全体敌人。
	/// 倒计时期间，每当队员受到伤害时，该技能的伤害量增加，增加量与所受伤害量相等，上限为治疗力的700%。
	/// 倒计时期间，帕露西受到的伤害量+100%。
	/// 释放后，根据所有敌人和友军的“诅咒”层数对目标追加攻击，每次攻击造成[40%治疗力]点伤害。
	/// </summary>
    public class S_Parsee_Rare_1:Skill_Extended, IP_SkillCastingStart, IP_SkillCastingQuit, IP_BuffAdd, IP_PlayerTurn, IP_DamageTakeChange
    {
        public int count = 0;
        public int countdmg = 0;
        public bool isCast = false;
        private Buff Tempbuff;

        public int PlusDmg
        {
            get
            {
                if (BattleSystem.instance == null || BattleSystem.instance.BattleLogs == null || BattleSystem.instance.TurnNum <= 0)
                {
                    return 0;
                }
                return (int)((float)(0 + this.BChar.GetStat.reg * 7.0));
            }
        }

        public int PlusDmg2
        {
            get
            {
                if (BattleSystem.instance == null || BattleSystem.instance.BattleLogs == null || BattleSystem.instance.TurnNum <= 0)
                {
                    return 0;
                }
                return (int)((float)(0 + this.BChar.GetStat.reg * 0.4));
            }
        }

        public override void Init()
        {
            base.Init();
            this.SkillBasePlus.Target_BaseDMG = countdmg;
            this.CountingExtedned = true;
            count = 0;
            countdmg = 0;
            isCast = false;

            this.SkillParticleObject = new GDESkillExtendedData(GDEItemKeys.SkillExtended_Public_1_Ex).Particle_Path;
        }

        public void Turn()
        {
            count = 0;
        }

        public void Buffadded(BattleChar BuffUser, BattleChar BuffTaker, Buff addedbuff)
        {
            if (addedbuff.BuffData.Key == "B_Parsee_P")
            {
                count++;
            }
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            this.SkillBasePlus.Target_BaseDMG = countdmg;

            if (count >= 14)
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
            this.SkillBasePlus.Target_BaseDMG = countdmg;
            

            if (count >= 14)
            {
                foreach (BattleChar battleChar in BattleSystem.instance.EnemyTeam.AliveChars)
                {
                    if (battleChar != Targets[0])
                    {
                        Targets.Add(battleChar);
                    }
                }
            }

            foreach (BattleChar bc in Targets)
            {
                this.Tempbuff = bc.BuffAdd(GDEItemKeys.Buff_B_Hein_8, this.BChar, true, 0, false, -1, false);
                (this.Tempbuff as B_Hein_8).MainSkill = this.MySkill;
            }

            foreach (BattleChar bc in Targets)
            {
                bc.Damage(this.BChar, PlusDmg, false, true);
            }


            int buffcount = 0;

            foreach (BattleChar bc in BattleSystem.instance.EnemyTeam.AliveChars)
            {
                buffcount += bc.BuffReturn("B_Parsee_P_1")?.StackNum ?? 0;
            }
            foreach (BattleChar bc in BattleSystem.instance.AllyTeam.AliveChars)
            {
                buffcount += bc.BuffReturn("B_Parsee_P_1")?.StackNum ?? 0;
            }

            BattleSystem.DelayInput(this.Effect(Targets, buffcount));
        }

        public IEnumerator Effect(List<BattleChar> Targets, int Count)
        {
            yield return new WaitForSeconds(0.15f);
            for (int i = 0; i < Count; i++)
            {
                foreach (BattleChar bc in Targets)
                {
                    Skill skill = Skill.TempSkill("S_Parsee_Rare_1_0", this.BChar, this.BChar.MyTeam);
                    skill.PlusHit = true;
                    if (!bc.IsDead)
                    {
                        this.BChar.ParticleOut(this.MySkill, skill, bc);
                    }
                }
                yield return new WaitForSeconds(0.1f);
            }
            yield break;
        }

        public int DamageTakeChange(BattleChar Hit, BattleChar User, int Dmg, bool Cri, bool NODEF = false, bool NOEFFECT = false, bool Preview = false)
        {
            if (isCast && User.Info.Ally && !Preview)
            {
                countdmg += Dmg;
            }

            if (countdmg >= (int)(7 * this.BChar.GetStat.reg))
            {
                countdmg = (int)(7 * this.BChar.GetStat.reg);
            }

            return Dmg;
        }

        public override string DescExtended(string desc)
        {
            return base.DescExtended(desc).Replace("&a", (this.PlusDmg).ToString())
                                          .Replace("&b", (this.PlusDmg2).ToString());
        }

        public void SkillCasting(CastingSkill ThisSkill)
        {
            countdmg = 0;
            isCast = true;
            this.BChar.BuffAdd("B_Parsee_Rare_1", this.BChar);
        }

        public void SkillCastingQuit(CastingSkill ThisSkill)
        {
            this.BChar.BuffReturn("B_Parsee_Rare_1")?.SelfDestroy();
        }
    }
}