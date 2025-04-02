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
namespace VillageAlice
{
	/// <summary>
	/// 爱丽丝
	/// Passive:
	/// 战斗开始时，进入[现实]。
	/// 在[现实]中，自身所属技能将【童话】化。
	/// 释放【童话】技能后，将进入[梦境]，在[梦境]中释放未被【童话】的技能将返回[现实]。
	/// </summary>
    public class P_VillageAlice:Passive_Char, IP_BattleStart_UIOnBefore
    {
        public void BattleStartUIOnBefore(BattleSystem Ins)
        {
            this.BChar.BuffAdd("B_FVAlice_P", this.BChar);
        }
    }

    public interface IP_ChangeReality
    {
        //false为现实，true为梦境
        void ChangeReality(bool istrue);
    }
}