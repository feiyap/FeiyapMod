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
namespace MinamiRio
{
	/// <summary>
	/// 正射必中
	/// </summary>
    public class B_MinamiRio_Rare_2:Buff, IP_DamageChange
    {
        public int DamageChange(Skill SkillD, BattleChar Target, int Damage, ref bool Cri, bool View)
        {
            return (int)(Damage * 1.35);
        }
    }
}