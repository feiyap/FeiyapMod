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
namespace Eirin
{
	/// <summary>
	/// 月人/月使
	/// 受到的追加攻击/反击伤害增加&a点。
	/// </summary>
    public class B_Eirin_3_0:Buff, IP_DamageChange_Hit_sumoperation
    {
        public override string DescExtended()
        {
            return base.DescExtended().Replace("&a", ((float)((int)base.Usestate_L.GetStat.reg) * 0.25f).ToString());
        }
        
        public void DamageChange_Hit_sumoperation(Skill SkillD, int Damage, ref bool Cri, bool View, ref int PlusDamage)
        {
            if (SkillD.PlusHit || SkillD.ExtendedFind("Lian_Ex_Counter", true) != null)
            {
                PlusDamage = (int)(base.Usestate_L.GetStat.reg * 0.25f);
            }
        }
    }
}