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
	/// 符卡能量
	/// </summary>
    public class B_YoumuF_Spell:Buff
    {
        public override void Init()
        {
            base.Init();
            if (this.StackNum >= 4)
            {
                SelfDestroy();
                this.BChar.BuffAdd("B_YoumuF_Spell2", this.BChar);
            }
        }
    }
}