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
namespace PatchouliKnowledge
{
	/// <summary>
	/// 水火符「燃素之雨」
	/// 重复释放 &count 次(1 + &count2)。
	/// 每次释放时，恢复体力值最低的友军 &a 点体力值(治疗力的45%)。
	/// 每个等级的“火”使这个技能额外造成&b点伤害(攻击力的5%)、额外治疗&c点体力(治疗力的5%)。
	/// 每个等级的“水”额外重复释放 1 次。
	/// </summary>
    public class S_Pachi_Sk_2_3:Skill_Extended
    {
        public int plusDamage
        {
            get
            {
                return (int)(this.BChar.GetStat.atk * 0.45f + 0.05f * BattleSystem.instance.GetBattleValue<BV_Pachi_P>().elementLevel[3]);
            }
        }
        
        public int plusHeal
        {
            get
            {
                return (int)(this.BChar.GetStat.reg * 0.45f + 0.05f * BattleSystem.instance.GetBattleValue<BV_Pachi_P>().elementLevel[3]);
            }
        }
        
        public override string DescExtended(string desc)
        {
            return base.DescExtended(desc).Replace("&a", ((int)(this.BChar.GetStat.reg * 0.45f)).ToString())
                                          .Replace("&b", ((int)(this.BChar.GetStat.atk * 0.05f)).ToString())
                                          .Replace("&d", ((int)(this.BChar.GetStat.reg * 0.05f)).ToString())
                                          .Replace("&c", (1 + BattleSystem.instance.GetBattleValue<BV_Pachi_P>().elementLevel[2]).ToString())
                                          .Replace("&e", (BattleSystem.instance.GetBattleValue<BV_Pachi_P>().elementLevel[2]).ToString());
        }

        public override void Init()
        {
            this.OnePassive = true;
            base.Init();
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);

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
                battleChar.Heal(this.BChar, plusHeal, false, false, null);
            }

            int count = 1 + BattleSystem.instance.GetBattleValue<BV_Pachi_P>().elementLevel[2];

            BattleSystem.DelayInput(this.Effect(Targets[0], count));
        }

        public IEnumerator Effect(BattleChar Target, int Count)
        {
            yield return new WaitForSeconds(0.2f);

            for (int i = 0; i < Count; i++)
            {
                Skill skill = Skill.TempSkill("S_Pachi_Sk_2_3", this.BChar, this.BChar.MyTeam);
                skill.PlusHit = true;
                skill.FreeUse = true;
                skill.isExcept = true;

                if (Target.IsDead)
                {
                    this.BChar.ParticleOut(this.MySkill, skill, this.BChar.BattleInfo.EnemyList.Random(this.BChar.GetRandomClass().Main));
                }
                else
                {
                    this.BChar.ParticleOut(this.MySkill, skill, Target);
                }

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
                    battleChar.Heal(this.BChar, plusHeal, false, false, null);
                }

                yield return new WaitForSeconds(0.2f);
            }
            yield break;
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            this.SkillBasePlus.Target_BaseDMG = (int)(this.BChar.GetStat.atk * (0.05 * BattleSystem.instance.GetBattleValue<BV_Pachi_P>().elementLevel[3]));
        }
    }
}