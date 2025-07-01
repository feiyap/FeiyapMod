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
namespace Feiyap
{
    /// <summary>
    /// 渴血症
    /// 其他友军被选定为技能的目标时，使目标改为指向自己；
    /// 增益持续期间，被动“绯夜流”的效果翻倍。
    /// 增益解除时，依据增益期间自身受到伤害的次数，对随机敌人追加攻击，每次造成&a伤害(攻击力的100%)。
    /// 当前受到伤害的次数：&b
    /// </summary>
    public class B_Feiyap_Rare_1:Buff, IP_TargetedAlly, IP_DamageTake
    {
        public int count = 0;

        public override void Init()
        {
            base.Init();
            count = 0;
            this.PlusStat.Strength = true;
        }

        public IEnumerator Targeted(BattleChar Attacker, List<BattleChar> SaveTargets, Skill skill)
        {
            bool flag = false;
            for (int i = 0; i < SaveTargets.Count; i++)
            {
                if (SaveTargets[i] == this.BChar)
                {
                    flag = true;
                    break;
                }
            }
            if (!flag)
            {
                for (int j = 0; j < SaveTargets.Count; j++)
                {
                    if (SaveTargets[j] != this.BChar)
                    {
                        SaveTargets[j] = this.BChar;
                        EffectView.TextOutSimple(this.BChar, this.BuffData.Name);
                    }
                }
            }
            return null;
        }

        public void DamageTake(BattleChar User, int Dmg, bool Cri, ref bool resist, bool NODEF = false, bool NOEFFECT = false, BattleChar Target = null)
        {
            if (Target == this.BChar && Dmg > 0)
            {
                count++;
            }
        }

        public override void SelfdestroyPlus()
        {
            base.SelfdestroyPlus();


            for (int i = 0; i < count; i++)
            {
                BattleSystem.DelayInput(this.PlusAttack());
            }
        }

        public IEnumerator PlusAttack()
        {
            yield return new WaitForSecondsRealtime(0.1f);

            yield return new WaitForFixedUpdate();
            Skill skill = Skill.TempSkill("S_Feiyap_Rare_1_0", this.BChar, this.BChar.MyTeam);
            skill.FreeUse = true;
            skill.PlusHit = true;

            Skill_Extended skill_Extended = new Skill_Extended();
            skill_Extended.PlusSkillStat.Penetration = 100f;
            skill.ExtendedAdd(skill_Extended);

            List<BattleChar> list = new List<BattleChar>();
            list.AddRange(BattleSystem.instance.EnemyTeam.AliveChars);

            this.BChar.ParticleOut(skill, list.Random(skill.Master.GetRandomClass().Main));

            yield break;
        }

        public override string DescExtended()
        {
            return base.DescExtended().Replace("&a", ((int)(this.BChar.GetStat.atk * 1.0)).ToString())
                                      .Replace("&b", (count).ToString());
        }
    }
}