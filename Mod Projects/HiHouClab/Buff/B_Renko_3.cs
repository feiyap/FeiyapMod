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
namespace HiHouClab
{
    /// <summary>
    /// 独一之翼
    /// 对体力值不低于50%的敌人造成伤害提升25%。
    /// </summary>
    public class B_Renko_3 : Buff, IP_DamageChange
    {
        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
        }

        public int DamageChange(Skill SkillD, BattleChar Target, int Damage, ref bool Cri, bool View)
        {
            if (Target.HP >= Target.GetStat.maxhp * 0.5f)
            {
                Damage = (int)(Damage * 1.25f);
            }
            return Damage;
        }
    }
}