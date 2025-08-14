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
namespace Phrolova
{
	/// <summary>
	/// 失亡彼岸
	/// 这个增益的“每回合伤害量”等于目标持有的所有减益“每回合伤害量”之和。
	/// </summary>
    public class B_Phrolova_Rare_1_2:Buff
    {
        public override void Init()
        {
            base.Init();
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            
            int num = 0;
            foreach (Buff buff in this.BChar.Buffs)
            {
                if (buff == this)
                {
                    continue;
                }
                num += buff.DotDMGView();
            }
            base.PlusDamageTick = num;
        }
    }
}