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
namespace HakureiReimu
{
	/// <summary>
	/// 幻想乡的守护者
	/// </summary>
    public class B_Musoutensei_Daiyousei_0:Buff, IP_DamageTake
    {
        public override string DescExtended()
        {
            if (BattleSystem.instance == null)
            {
                return base.DescExtended().Replace("&user", "")
                                          .Replace("&a", (0).ToString());
            }

            return base.DescExtended().Replace("&user", this.BChar.Info.Name)
                                      .Replace("&a", ((int)((float)this.BChar.GetStat.atk * 0.5f)).ToString());
        }

        public void DamageTake(BattleChar User, int Dmg, bool Cri, ref bool resist, bool NODEF = false, bool NOEFFECT = false, BattleChar Target = null)
        {
            if (Dmg >= 1 && !User.Info.Ally && !resist)
            {
                Skill skill = Skill.TempSkill("S_Musoutensei_Daiyousei_1", this.BChar, this.BChar.MyTeam);
                skill.PlusHit = true;
                BattleSystem.DelayInput(this.EirinAttack(skill, User, this.BChar));
            }
        }

        public IEnumerator EirinAttack(Skill skill, BattleChar hit, BattleChar use)
        {
            yield return new WaitForSecondsRealtime(0.1f);
            if (!hit.IsDead)
            {
                use.ParticleOut(skill, hit);
            }
            else if (hit.Info.Ally)
            {
                use.ParticleOut(skill, BattleSystem.instance.AllyList.Random(this.BChar.GetRandomClass().Main));
            }
            else
            {
                use.ParticleOut(skill, BattleSystem.instance.EnemyList.Random(this.BChar.GetRandomClass().Main));
            }
            yield return null;
            yield break;
        }
    }
}