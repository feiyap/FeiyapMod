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
    /// 物理学圣剑
    /// 对体力值不低于90%的敌人造成伤害+75%。
    /// </summary>
    public class E_Renko_0 : EquipBase, IP_DamageChange
    {
        public override void Init()
        {
            base.Init();
            this.PlusStat.atk = 2;
            this.PlusStat.cri = 10;
        }

        public int DamageChange(Skill SkillD, BattleChar Target, int Damage, ref bool Cri, bool View)
        {
            if (Target.HP * 100 / Target.GetStat.maxhp >= 90)
            {
                Damage = (int)(Damage * 1.75f);
            }

            return Damage;
        }
    }
}