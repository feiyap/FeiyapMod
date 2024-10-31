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
	/// 全神贯注
	/// 使自身下1个2费以上的技能造成的伤害提升25%。
	/// </summary>
    public class B_MinamiRio_2:Buff, IP_DamageChange
    {
        public int DamageChange(Skill SkillD, BattleChar Target, int Damage, ref bool Cri, bool View)
        {
            if (SkillD.AP >= 2 && Damage > 1 && !View)
            {
                if (SkillD.MySkill.KeyID == "S_MinamiRio_3")
                {
                    this.SelfDestroy();
                    return (int)(Damage * 1.5);
                }
                else
                {
                    this.SelfDestroy();
                    return (int)(Damage * 1.25);
                }
            }
            return Damage;
        }
    }
}