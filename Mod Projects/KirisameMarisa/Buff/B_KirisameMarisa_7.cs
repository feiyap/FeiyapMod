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
namespace KirisameMarisa
{
	/// <summary>
	/// 危险冲击
	/// 无法指定其他角色。
	/// </summary>
    public class B_KirisameMarisa_7:Buff, IP_HPChange
    {
        public override void Init()
        {
            base.Init();
            this.PlusPerStat.Damage = 15;
            this.PlusStat.DMGTaken = 15;
            this.PlusStat.spd = -5;
            this.PlusStat.dod = -300;
            this.PlusStat.Penetration = 100;
            this.PlusStat.IgnoreTaunt = true;
            this.PlusStat.def = this.BChar.GetStat.atk;
        }

        public void HPChange(BattleChar Char, bool Healed)
        {
            if (Char.HP <= 0)
            {
                SelfDestroy();
            }
        }
    }
}