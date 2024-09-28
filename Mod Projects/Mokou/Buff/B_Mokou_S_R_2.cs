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
    /// 「不死鸟重生」
    /// </summary>
    public class B_Mokou_S_R_2 : Buff
    {
        public override void Init()
        {
            base.Init();
            this.PlusStat.maxhp = (10 * base.StackNum);
        }
    }
}