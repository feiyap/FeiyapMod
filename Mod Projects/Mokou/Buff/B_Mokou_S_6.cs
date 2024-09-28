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
	/// 轮回
	/// </summary>
    public class B_Mokou_S_6:Buff
    {
        public override void Init()
        {
            base.Init();
            this.PlusStat.maxhp = (3 * base.StackNum);
        }
    }
}