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
namespace Inaba
{
	/// <summary>
	/// 因幡/兔运
	/// 命中时消耗1层，使目标防御力-4%，闪避率-4%。最多叠加5次。
	/// </summary>
    public class B_Inaba_8:Buff, IP_DamageChange
    {
        public override void Init()
        {
            this.PlusStat.cri = 25;
        }

        public int DamageChange(Skill SkillD, BattleChar Target, int Damage, ref bool Cri, bool View)
        {
            if (SkillD.PlusHit && SkillD.Master == this.BChar && Cri && !View)
            {
                this.PlusStat.PlusCriDmg += 10;
            }
            return Damage;
        }
    }
}