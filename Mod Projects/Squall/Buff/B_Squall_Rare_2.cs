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
namespace Squall
{
	/// <summary>
	/// 狮子之心
	/// [刃甲]的最高层数增加到15。
	/// 每获得一层[刃甲]，增加2%攻击力。
	/// 追加攻击和反击的伤害增加&a点(攻击力的20%)。
	/// </summary>
    public class B_Squall_Rare_2:Buff, IP_DamageChange
    {
        public override void Init()
        {
            base.Init();
            this.PlusPerStat.Damage = this.BChar.BuffReturn("B_Squall_P")?.StackNum * 2 ?? 0;
            this.PlusStat.cri = 15;
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            this.PlusPerStat.Damage = this.BChar.BuffReturn("B_Squall_P")?.StackNum * 2 ?? 0;
        }

        public int DamageChange(Skill SkillD, BattleChar Target, int Damage, ref bool Cri, bool View)
        {
            if (!Target.Info.Ally && (SkillD.PlusHit || SkillD.ExtendedFind("Lian_Ex_Counter", true) != null))
            {
                Damage = Damage + (int)(this.BChar.GetStat.atk * 0.2f);
            }
            return Damage;
        }

        public override string DescExtended()
        {
            return base.DescExtended().Replace("&a", ((int)(this.BChar.GetStat.atk * 0.2f)).ToString());
        }
    }
}