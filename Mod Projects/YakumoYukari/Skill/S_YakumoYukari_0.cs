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

namespace YakumoYukari
{
    /// <summary>
    /// 执行动作
    /// 无指向。消耗所点的动作槽。
    /// </summary>
    public class S_YakumoYukari_0 : SE_YakumoYukari_Action
    {
        protected override void ApplyKeyDefaults()
        {
            this.ActionType = YukariActionType.Any;
            this.CannotLevel = true;
            this.ForceTick = false;
            this.BoundaryCost = 0;
        }
    }
}
