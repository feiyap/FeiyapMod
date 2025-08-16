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
namespace FAlice
{
    /// <summary>
    /// ²Ô·û¡¸²©°®µÄ°Â¶ûÁ¼ÈËÐÎ¡¹
    /// </summary>
    public class B_FAlice_2 : Buff
    {
        public override void Init()
        {
            base.Init();
            this.PlusStat.reg = StackNum;
            this.NoShowTimeNum_Tooltip = true;
        }
    }
}