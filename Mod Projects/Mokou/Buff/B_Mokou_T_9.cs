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
namespace Mokou
{
	/// <summary>
	/// 火焰萃取
	/// 行动时，自身每拥有1层烧伤痛苦减益，治疗妹红1.5%最大体力值的体力值。
	/// </summary>
    public class B_Mokou_T_9: Buff
    {
		public override void Init()
        {
            base.Init();
        }
        public override void TurnUpdate()
        {
            base.TurnUpdate();
            if (this.BChar.BuffFind("B_Mokou_T_1", false))
            {
                int i = this.BChar.BuffReturn("B_Mokou_T_1", false).StackNum;
                float num = 0f;
                num = (float)((float)base.Usestate_F.Info.get_stat.maxhp * 0.03 * i);
                base.Usestate_F.Heal(base.Usestate_F, num, false, false, null);
            }
        }
    }
}