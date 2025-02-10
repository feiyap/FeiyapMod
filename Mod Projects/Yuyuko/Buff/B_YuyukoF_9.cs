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
namespace Yuyuko
{
	/// <summary>
	/// 樱散蝶
	/// 体力值不会降低至1以下。
	/// </summary>
    public class B_YuyukoF_9:Buff, IP_HPChange
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