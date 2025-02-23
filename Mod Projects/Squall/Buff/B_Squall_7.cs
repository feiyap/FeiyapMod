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
	/// 逆命者
	/// 自身生命值不会降到1以下。
	/// </summary>
    public class B_Squall_7:Buff, IP_HPChange
    {
        public override void Init()
        {
            base.Init();
            this.PlusStat.Strength = true;
            if (this.BChar.HP <= 0)
            {
                this.BChar.HP = 1;
            }
        }

        public void HPChange(BattleChar Char, bool Healed)
        {
            if (this.BChar.HP <= 0)
            {
                this.BChar.HP = 1;
            }
        }
    }
}