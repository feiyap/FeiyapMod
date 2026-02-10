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
namespace FeiyapTank
{
    /// <summary>
    /// 错身
    /// 不会因为受到伤害导致无法战斗。
    /// 回合开始时解除 1 层。
    /// </summary>
    public class B_FeiyapTank_0 : Buff
    {
        public override void Init()
        {
            base.Init();
            this.PlusStat.DMGTaken = 5 * StackNum;
        }
    }
}