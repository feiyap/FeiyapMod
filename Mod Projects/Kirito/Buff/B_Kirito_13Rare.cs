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
namespace Kirito
{
	/// <summary>
	/// 还没结束
	/// 濒死时，攻击力+50%。
	/// </summary>
    public class B_Kirito_13Rare:Buff, IP_HPChange
    {
        public override void Init()
        {
            base.Init();
            this.PlusStat.DeadImmune = 100;
        }

        public void HPChange(BattleChar Char, bool Healed)
        {
            if (Char.HP <= 0)
            {
                this.PlusStat.atk = 50f;
            }
            else
            {
                this.PlusStat.atk = 0f;
            }
        }
    }
}