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
namespace Morichika
{
	/// <summary>
	/// 财源滚滚
	/// 场上每有 1 个持有“保修服务”的友军，这个增益额外提供“最大体力值+25%”。
	/// </summary>
    public class B_Morichika_6:Buff
    {
        public override void Init()
        {
            base.Init();
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();

            int count = 0;
            foreach (BattleChar bc in BattleSystem.instance.AllyList)
            {
                if (bc.BuffFind("B_Morichika_P"))
                {
                    count++;
                }
            }
            this.PlusPerStat.MaxHP = count * 25;
        }
    }
}