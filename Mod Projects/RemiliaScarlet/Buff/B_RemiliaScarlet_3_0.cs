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
namespace RemiliaScarlet
{
	/// <summary>
	/// 绯月女皇
	/// 场上每有1层痛苦减益，这个增益获得“暴击率+5%，受到治疗量+5%”。
	/// </summary>
    public class B_RemiliaScarlet_3_0:Buff
    {
        public int Fixed_count = 0;

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            Fixed_count++;

            if (Fixed_count >= 12)
            {
                Fixed_count = 0;

                int count = 0;
                foreach (BattleChar bc in BattleSystem.instance.AllyList)
                {
                    count += bc.GetBuffs(BattleChar.GETBUFFTYPE.DOT, true, false).Count;
                }
                foreach (BattleChar bc in BattleSystem.instance.EnemyList)
                {
                    count += bc.GetBuffs(BattleChar.GETBUFFTYPE.DOT, true, false).Count;
                }

                this.PlusStat.cri = 5 * count;
                this.PlusStat.HEALTaken = 5 * count;
            }
        }
    }
}