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
namespace FairyLancelot
{
	/// <summary>
	/// 你已完全属于我
	/// </summary>
    public class B_FLancelot_4_0:Buff, IP_DamageChange
    {
        public override void Init()
        {
            base.Init();
            this.PlusStat.atk = BattleSystem.instance.EnemyList.Find(t => t.BuffFind("B_FLancelot_3"))?.GetStat.atk ?? 0;
            this.PlusStat.Penetration = 20;
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            this.PlusStat.atk = BattleSystem.instance.EnemyList.Find(t => t.BuffFind("B_FLancelot_3"))?.GetStat.atk ?? 0;
        }

        public int DamageChange(Skill SkillD, BattleChar Target, int Damage, ref bool Cri, bool View)
        {
            if (Target == BattleSystem.instance.EnemyList.Find(t => t.BuffFind("B_FLancelot_3")))
            {
                Damage = Damage * 2;
            }

            return Damage;
        }
    }
}