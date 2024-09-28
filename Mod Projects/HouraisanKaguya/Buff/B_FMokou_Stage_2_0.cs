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
namespace HouraisanKaguya
{
	/// <summary>
	/// 月岩笠的诅咒
	/// </summary>
    public class B_FMokou_Stage_2_0:Buff, IP_DamageTakeChange, IP_DamageChange
    {
        public int DamageChange(Skill SkillD, BattleChar Target, int Damage, ref bool Cri, bool View)
        {
            bool flag = SkillD.Master == this.BChar && Target == base.Usestate_F;
            int result;
            if (flag)
            {
                result = (int)((double)Damage * 0.5);
            }
            else
            {
                result = Damage;
            }
            return result;
        }
        
        public int DamageTakeChange(BattleChar Hit, BattleChar User, int Dmg, bool Cri, bool NODEF = false, bool NOEFFECT = false, bool Preview = false)
        {
            bool flag = Hit == this.BChar && User == base.Usestate_F;
            int result;
            if (flag)
            {
                result = (int)((double)Dmg * 0.5);
            }
            else
            {
                result = Dmg;
            }
            return result;
        }
    }
}