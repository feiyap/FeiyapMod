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
namespace ShameimaruAya
{
	/// <summary>
	/// 旋符「红叶扇风」
	/// 重复释放2次。这个技能无视防御。
	/// 暴击时生成1个[北风灵]。
	/// <b><color=green>连击8</color></b> - 将弃牌堆最上方的技能放回牌堆顶，抽取1个技能。
	/// </summary>
    public class S_Shameimaru_2: SE_Shameimaru_Combo, IP_SkillUse_Target
    {
        public override void Init()
        {
            base.Init();
            this.SkillParticleObject = new GDESkillExtendedData(GDEItemKeys.SkillExtended_Public_1_Ex).Particle_Path;
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            if (CheckUsedSkills(8))
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
            BattleSystem.DelayInputAfter(this.Ienum(Targets));
            BattleSystem.DelayInputAfter(this.Ienum(Targets));

            if (CheckUsedSkills(8))
            {
                Skill skill = BattleSystem.instance.AllyTeam.Skills_UsedDeck.FirstOrDefault((Skill s) => s.CharinfoSkilldata != this.MySkill.CharinfoSkilldata);
                if (skill != null)
                {
                    BattleSystem.instance.AllyTeam.Skills_UsedDeck.Remove(skill);
                    BattleSystem.instance.AllyTeam.Skills_Deck.Insert(0, skill);
                    BattleSystem.instance.AllyTeam.Draw();
                }
            }
        }

        public IEnumerator Ienum(List<BattleChar> Targets)
        {
            yield return new WaitForSecondsRealtime(0.1f);
            Skill skill = Skill.TempSkill("S_Shameimaru_2_0", this.BChar, this.BChar.MyTeam);
            skill.PlusHit = true;
            skill.isExcept = true;
            skill.FreeUse = true;
            Skill_Extended skill_Extended = new Skill_Extended();
            skill_Extended.IsDamage = true;
            skill_Extended.PlusSkillStat.Penetration = 100f;
            skill.ExtendedAdd(skill_Extended);
            if (Targets[0].IsDead)
            {
                this.BChar.ParticleOut(this.MySkill, skill, this.BChar.BattleInfo.EnemyList.Random(this.BChar.GetRandomClass().Main));
            }
            else
            {
                this.BChar.ParticleOut(this.MySkill, skill, Targets[0]);
            }
            yield break;
        }

        public void AttackEffect(BattleChar hit, SkillParticle SP, int DMG, bool Cri)
        {
            if (Cri)
            {
                Skill tmpSkill = Skill.TempSkill("S_Shameimaru_P", this.BChar, this.BChar.MyTeam);
                BattleSystem.instance.AllyTeam.Add(tmpSkill, true);
            }
        }
    }
}