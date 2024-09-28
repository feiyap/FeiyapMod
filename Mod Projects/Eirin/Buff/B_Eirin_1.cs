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
	/// 月人/乾坤
	/// 造成的追加攻击/反击的伤害+33%。
	/// </summary>
    public class B_Eirin_1:Buff, IP_DamageChange
    {
        public override void Init()
        {
            base.Init();
        }
        
        public int DamageChange(Skill SkillD, BattleChar Target, int Damage, ref bool Cri, bool View)
        {
            if (!Target.Info.Ally && (SkillD.PlusHit || SkillD.ExtendedFind("Lian_Ex_Counter", true) != null))
            {
                Damage = Damage * 133 / 100;
            }
            return Damage;
        }
    }
}