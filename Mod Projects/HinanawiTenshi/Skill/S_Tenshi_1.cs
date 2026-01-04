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
	/// 地符「不让土壤之剑」
	/// 如果自己身上有<color=#B22222>天</color><color=#00BFFF>气</color><color=#00FF7F>增</color><color=#FFD700>益</color>，消耗1个<color=#B22222>天</color><color=#00BFFF>气</color><color=#00FF7F>增</color><color=#FFD700>益</color>，重复释放1次。
	/// <color=#97FFFF>天启5</color> - 使目标获得“受到伤害量+15%”，持续3回合。
	/// </summary>
    public class S_Tenshi_1: SkillBase_Tenshi
    {
        public override void FixedUpdate()
        {
            base.FixedUpdate();
            Fixed_count++;

            if (Fixed_count >= 12)
            {
                Fixed_count = 0;

                if (CheckKishi(5, true))
                {
                    base.SkillParticleOn();
                }
                else
                {
                    base.SkillParticleOff();
                }
            }
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            int count = BattleSystem.instance.GetBattleValue<BV_Tenshi_P>().list.Count;

            

            if (CheckKishi(5, false))
            {
                BattleSystem.DelayInput(this.Effect2(Targets[0], count));
            }
            else
            {
                BattleSystem.DelayInput(this.Effect(Targets[0], count));
            }
        }

        public IEnumerator Effect(BattleChar Target, int Count)
        {
            yield return new WaitForSeconds(0.15f);
            int num;
            for (int i = 0; i < Count; i = num + 1)
            {
                if (BattleSystem.instance.EnemyTeam.AliveChar_GetInstance().Count != 0)
                {
                    Skill skill = Skill.TempSkill("S_Tenshi_1_0", this.BChar, this.BChar.MyTeam);
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
                yield return new WaitForSeconds(0.1f);
                num = i;
            }
            yield break;
        }

        public IEnumerator Effect2(BattleChar Target, int Count)
        {
            yield return new WaitForSeconds(0.15f);
            int num;
            for (int i = 0; i < Count; i = num + 1)
            {
                if (BattleSystem.instance.EnemyTeam.AliveChar_GetInstance().Count != 0)
                {
                    Skill skill = Skill.TempSkill("S_Tenshi_1_1", this.BChar, this.BChar.MyTeam);
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
                yield return new WaitForSeconds(0.1f);
                num = i;
            }
            yield break;
        }

        //public IEnumerator PlusAttack(BattleChar hit)
        //{
        //    yield return new WaitForSecondsRealtime(0.3f);
        //    Skill skill = Skill.TempSkill("S_Tenshi_1", this.BChar, this.BChar.MyTeam);
        //    if (this.BChar != null && !this.BChar.Dummy && !this.BChar.IsDead)
        //    {
        //        if (!hit.IsDead)
        //        {
        //            this.BChar.ParticleOut(this.MySkill, skill, hit);
        //        }
        //        else if (BattleSystem.instance.EnemyList.Count > 0)
        //        {
        //            this.BChar.ParticleOut(this.MySkill, skill, this.BChar.BattleInfo.EnemyList.Random(this.BChar.GetRandomClass().Main));
        //        }
        //    }
        //    yield break;
        //}

        public override string DescExtended(string desc)
        {
            return base.DescExtended(desc).Replace("&a", ((int)(this.BChar.GetStat.atk * 0.35f)).ToString())
                                          .Replace("&b", ((int)(this.BChar.GetStat.atk * 0.5f)).ToString());
        }
    }
}