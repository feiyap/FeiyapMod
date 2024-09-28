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
namespace ShameimaruAya
{
	/// <summary>
	/// 风来的瀑流
	/// 使用0费技能造成的伤害+15%。
	/// </summary>
    public class B_Shameimaru_4:Buff
    {
        public int DamageChange(Skill SkillD, BattleChar Target, int Damage, ref bool Cri, bool View)
        {
            if (!Target.Info.Ally && ((!SkillD.NotCount && SkillD.AP <= 1) || SkillD.AP <= 0))
            {
                Damage += (int)(Damage * 0.15 * this.StackNum);
            }
            return Damage;
        }

        public override string DescExtended()
        {
            return base.DescExtended().Replace("&a", ((int)(15 * this.StackNum)).ToString());
        }
    }
}