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
	/// 「蓬莱人形」
	/// 如果自身有烧伤，保护体力极限。
	/// </summary>
    public class B_Mokou_S_5:Buff
    {
        public override void FixedUpdate()
        {
            if (EX_ability.CheckEXburn(1, this.BChar))
            {
                this.PlusStat.Strength = true;
            }
            else
            {
                this.PlusStat.Strength = false;
            }
        }
    }
}