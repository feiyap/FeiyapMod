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
	/// 龙泪
	/// 每次行动时受到 2% 最大体力值的伤害。
	/// </summary>
    public class B_FLancelot_10_0:Buff
    {
        public override void TurnUpdate()
        {
            base.TurnUpdate();

            this.BChar.Damage(this.Usestate_F, this.BChar.GetStat.maxhp * 2 * StackNum / 100, false, true);
        }
    }
}