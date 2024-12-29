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
namespace HinanawiTenshi
{
	/// <summary>
	/// 天气「绯想天促」
	/// 同时对目标左右的单位释放，造成一半的伤害。
	/// 命中时，自身获得随机天气增益。
	/// <color=#97FFFF>天启7</color> - 如果场上的敌人数量大于1，改为指向“所有敌人”。
	/// </summary>
    public class S_Tenshi_3: SkillBase_Tenshi
    {
        public override void FixedUpdate()
        {
            base.FixedUpdate();
            Fixed_count++;

            if (Fixed_count >= 12)
            {
                Fixed_count = 0;

                if (CheckKishi(7, true))
                {
                    base.SkillParticleOn();
                    this.MySkill.MySkill.Target = new GDEs_targettypeData(GDEItemKeys.s_targettype_all_enemy);
                }
                else
                {
                    base.SkillParticleOff();
                    this.MySkill.MySkill.Target = new GDEs_targettypeData(GDEItemKeys.s_targettype_enemy);
                }
            }
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);

            if (BattleSystem.instance.EnemyList.Count > 1 && CheckKishi(7, false))
            {
                if (!BattleSystem.instance.GetBattleValue<BV_Tenshi_P>().list.Exists(count => count == 7))
                {

                }
            }
            else
            {
                BattleSystem.DelayInput(this.Damage1(Targets[0].MyLeftCharReturn()));
                BattleSystem.DelayInput(this.Damage1(Targets[0].MyRightCharReturn()));
            }
        }

        public IEnumerator Damage1(BattleChar Target)
        {
            Skill skill = Skill.TempSkill("S_Tenshi_3", this.BChar, this.BChar.MyTeam);
            skill.MySkill.Effect_Target.DMG_Per = 45;
            this.BChar.ParticleOut(skill, Target);
            yield break;
        }

        public override void AttackEffectSingle(BattleChar hit, SkillParticle SP, int DMG, int Heal)
        {
            AddTenki(this.BChar, 1);
        }
    }
}