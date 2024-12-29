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
namespace HinanawiTenshi
{
	/// <summary>
	/// 天气 - 晴岚
	/// 追加攻击/反击造成的伤害提升33%。
	/// </summary>
    public class B_Tenki_12:Buff, IP_DamageChange
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