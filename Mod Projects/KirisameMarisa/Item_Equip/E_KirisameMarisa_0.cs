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
namespace KirisameMarisa
{
	/// <summary>
	/// 开拓星空的八卦炉
	/// 攻击未暴击时，造成的伤害降低80%。
	/// </summary>
    public class E_KirisameMarisa_0:EquipBase, IP_DamageChange
    {
        public override void Init()
        {
            base.Init();
            this.PlusStat.atk = 5;
            this.PlusStat.def = -40;
            this.PlusStat.PlusCriDmg = 200;
        }

        public int DamageChange(Skill SkillD, BattleChar Target, int Damage, ref bool Cri, bool View)
        {
            if (!Cri)
            {
                return (int)(Damage * 0.2);
            }
            return Damage;
        }
    }
}