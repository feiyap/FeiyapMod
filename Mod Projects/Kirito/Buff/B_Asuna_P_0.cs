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
    /// 准备开饭
    /// 回合开始时，消耗1层恢复5点体力。
    /// </summary>
    public class B_Asuna_P_0 : Buff, IP_PlayerTurn_1
    {
        public void Turn1()
        {
            if (base.Usestate_F.IsDead)
            {
                base.SelfDestroy(false);
                return;
            }
            this.BChar.Heal(this.BChar, 5, false, false, null);
            base.SelfStackDestroy();
        }
    }
}