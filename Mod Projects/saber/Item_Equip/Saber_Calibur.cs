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
namespace saber
{
	/// <summary>
	/// 石中剑
	/// </summary>
    public class Saber_Calibur:EquipBase, IP_BattleStart_Ones
    {
        public override void Init()
        {
            base.Init();
            this.PlusPerStat.Damage = 25;
            this.PlusStat.cri = 20f;
            this.PlusStat.HIT_CC = 15;
            this.PlusStat.HIT_DOT = 15;
            this.PlusStat.HIT_DEBUFF = 15;
        }
        public void BattleStart(BattleSystem Ins)
        {
            bool flag = this.BChar.Info.KeyData == "Saber";
            if (flag)
            {
                this.PlusStat.spd += 1;
                this.PlusStat.Penetration += 15f;
            }
        }
    }
}