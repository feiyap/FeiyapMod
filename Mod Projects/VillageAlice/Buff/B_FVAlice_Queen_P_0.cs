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
namespace VillageAlice
{
	/// <summary>
	/// 砍掉他的头
	/// </summary>
    public class B_FVAlice_Queen_P_0:Buff, IP_ChaosDamageTake
    {
        public void ChaosDamageTake(BattleChar User, int Dmg, bool Cri, ref bool resist, bool NODEF, bool NOEFFECT, BattleChar Target)
        {
            if (Dmg > 0)
            {
                BattleSystem.DelayInputAfter(this.Attack(Target));
            }
        }

        public IEnumerator Attack(BattleChar bc)
        {
            yield return new WaitForSecondsRealtime(0.5f);

            Skill skill = Skill.TempSkill("S_FVAlice_Queen_0", this.Usestate_F, this.Usestate_F.MyTeam);
            skill.isExcept = true;
            skill.FreeUse = true;
            skill.PlusHit = true;

            if (bc != null || bc.IsDead)
            {
                this.BChar.ParticleOut(skill, bc);
            }

            yield break;
        }
    }
}