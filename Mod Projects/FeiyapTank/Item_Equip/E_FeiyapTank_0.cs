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
namespace FeiyapTank
{
	/// <summary>
	/// 无铭刃
	/// 体力值低于 1 时，这件装备的属性提升200%。
	/// </summary>
    public class E_FeiyapTank_0:EquipBase, IP_HPChange
    {
        public void HPChange(BattleChar Char, bool Healed)
        {
            if (this.BChar.HP < 1)
            {
                this.PlusStat.cri = 100;
                this.PlusStat.PlusCriDmg = 100;
            }
            else
            {
                this.PlusStat.cri = 33;
                this.PlusStat.PlusCriDmg = 33;
            }
        }

        public override void Init()
        {
            base.Init();
            this.PlusStat.cri = 33;
            this.PlusStat.PlusCriDmg = 33;
        }
    }
}