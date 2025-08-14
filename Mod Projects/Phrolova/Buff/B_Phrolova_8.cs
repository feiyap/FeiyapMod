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
namespace Phrolova
{
    /// <summary>
    /// 遗失的提琴声
    /// 下 1 个对&user释放的单体技能伤害量/治疗量提升100%，然后解除该增益。
    /// 回合结束时，对&user释放 1 次“基础攻击”，然后解除该增益。
    /// </summary>
    public class B_Phrolova_8 : Buff, IP_DamageChange, IP_TurnEnd, IP_Heal_User
    {
        public int DamageChange(Skill SkillD, BattleChar Target, int Damage, ref bool Cri, bool View)
        {
            if (Target == this.Usestate_F && SkillD.Master == this.BChar && Damage > 0)
            {
                Damage = Damage * 2;
                if (!View )
                {
                    BattleSystem.instance.AllyTeam.CharacterDraw(this.Usestate_F);
                    Debug.Log(Damage);
                    SelfDestroy();
                }
            }

            return Damage;
        }


        public int Heal_User(BattleChar Target, int HealNum)
        {
            if (Target == this.Usestate_F)
            {
                HealNum = HealNum * 1;
                BattleSystem.instance.AllyTeam.CharacterDraw(this.Usestate_F);
                SelfDestroy();
            }

            return HealNum;
        }

        public void TurnEnd()
        {
            BattleSystem.DelayInput(this.AllyAttack());
        }

        public IEnumerator AllyAttack()
        {
            Skill skill = Skill.TempSkill("S_Phrolova_8_0", this.BChar, this.BChar.MyTeam);
            skill.FreeUse = true;
            yield return BattleSystem.instance.StartCoroutine(BattleSystem.instance.ForceAction(skill, this.Usestate_F, false, true, false, null));


            yield break;
        }

        public override string DescExtended()
        {
            return this.BuffData.Description.Replace("&user", this.Usestate_F.Info.Name);
        }
    }
}