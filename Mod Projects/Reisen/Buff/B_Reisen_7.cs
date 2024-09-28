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
namespace Reisen
{
    /// <summary>
    /// 真实/幻象
    /// 每个回合开始时，获得3颗[子弹]。
    /// </summary>
    public class B_Reisen_7:Buff, IP_PlayerTurn
    {
        public void Turn()
        {
            this.BChar.BuffAdd("B_Reisen_P_Bullet", this.BChar, false, 0, false, -1, false);
            this.BChar.BuffAdd("B_Reisen_P_Bullet", this.BChar, false, 0, false, -1, false);
            this.BChar.BuffAdd("B_Reisen_P_Bullet", this.BChar, false, 0, false, -1, false);
        }
    }
}