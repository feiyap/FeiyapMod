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
namespace Reisen
{
	/// <summary>
	/// 花冠视线
	/// </summary>
    public class B_Reisen_3:Buff, IP_DamageChange
    {
        //public void Turn()
        //{
        //    Skill skill = Skill.TempSkill("S_Reisen_3_1", this.BChar, this.BChar.MyTeam);
        //    skill.isExcept = true;
        //    skill.FreeUse = true;
        //    skill.PlusHit = true;
        //    skill.NoAttackTimeWait = true;
        //    this.BChar.ParticleOut(skill, BattleSystem.instance.EnemyTeam.AliveChars.Random(this.BChar.GetRandomClass().Main));

        //    this.SelfDestroy();
        //}

        public override void Init()
        {
            base.Init();
        }

        public int DamageChange(Skill SkillD, BattleChar Target, int Damage, ref bool Cri, bool View)
        {
            if (!Target.Info.Ally && (SkillD.PlusHit || SkillD.ExtendedFind("Lian_Ex_Counter", true) != null))
            {
                Damage += (int)base.Usestate_L.GetStat.atk * 33 / 100;
            }
            return Damage;
        }

        public override string DescExtended()
        {
            return base.DescExtended().Replace("&a", ((float)((int)base.Usestate_L.GetStat.atk) * 0.33f).ToString());
        }
    }
}