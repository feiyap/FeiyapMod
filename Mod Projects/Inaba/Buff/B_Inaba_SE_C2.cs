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
	/// 因幡/协运
	/// 受到的追加攻击伤害+100%。
	/// </summary>
    public class B_Inaba_SE_C2:Buff, IP_DamageChange
    {
        public override void Init()
        {
            base.Init();
        }

        public int DamageChange(Skill SkillD, BattleChar Target, int Damage, ref bool Cri, bool View)
        {
            if (!Target.Info.Ally && (SkillD.PlusHit || SkillD.ExtendedFind("Lian_Ex_Counter", true) != null))
            {
                Damage = Damage * 200 / 100;
            }
            return Damage;
        }
    }
}