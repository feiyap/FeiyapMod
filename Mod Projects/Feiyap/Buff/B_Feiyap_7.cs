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
	/// 镜花水月
	/// </summary>
    public class B_Feiyap_7:Buff, IP_Dodge
    {
        public override void Init()
        {
            base.Init();
            this.PlusStat.PerfectDodge = true;
        }

        public void Dodge(BattleChar Char, SkillParticle SP)
        {
            if (Char == this.BChar)
            {
                BattleSystem.DelayInputAfter(this.Attack(SP.SkillData.Master));
            }
        }

        public IEnumerator Attack(BattleChar bc)
        {
            yield return new WaitForSecondsRealtime(0.25f);

            Skill skill = Skill.TempSkill("S_Feiyap_7_0", this.BChar, this.BChar.MyTeam);
            skill.isExcept = true;
            skill.FreeUse = true;
            skill.PlusHit = true;

            if (bc != null || bc.IsDead)
            {
                this.BChar.ParticleOut(skill, bc);
            }
            else if (BattleSystem.instance.EnemyTeam.AliveChars.Count != 0)
            {
                this.BChar.ParticleOut(skill, BattleSystem.instance.EnemyTeam.AliveChars.Random(this.BChar.GetRandomClass().Main));
            }

            this.SelfDestroy();

            yield break;
        }

        public override string DescExtended()
        {
            int dmg = 0;
            if (base.Usestate_L != null)
            {
                dmg = (int)(base.Usestate_L.GetStat.atk * 1);
            }

            return this.BuffData.Description.Replace("&a", dmg.ToString());
        }
    }
}