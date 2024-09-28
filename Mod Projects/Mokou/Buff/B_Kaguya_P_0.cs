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
	/// 蓬莱之躯
	/// 生命值无法降低到1以下。每当生命值降到1时，本回合内免疫伤害并将于下回合进入下一阶段。
	/// </summary>
    public class B_Kaguya_P_0:Buff, IP_HPChange
    {
        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
        }
        public void HPChange(BattleChar Char, bool Healed)
        {
            if (this.BChar.HP <= 1 )
            {
                this.BChar.Info.Hp = 1;
                this.PlusStat.invincibility = true;
            }
            else
            {
                this.PlusStat.invincibility = false;
            }
        }
    }
}