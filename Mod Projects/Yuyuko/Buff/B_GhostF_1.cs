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
	/// 凭依之缚
	/// </summary>
    public class B_GhostF_1:Buff, IP_DamageTakeChange
    {
        public int DamageTakeChange(BattleChar Hit, BattleChar User, int Dmg, bool Cri, bool NODEF = false, bool NOEFFECT = false, bool Preview = false)
        {
            if (Hit.Info.KeyData == "Boss_Youmu")
            {
                Dmg += this.StackNum;
            }
            return Dmg;
        }
    }
}