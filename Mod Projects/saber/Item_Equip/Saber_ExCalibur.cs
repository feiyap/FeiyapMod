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
	/// <color=#F0BC1F>誓约胜利之剑</color>
	/// </summary>
    public class Saber_ExCalibur:EquipBase, IP_BattleStart_Ones
    {
        public override void Init()
        {
            base.Init();
            this.PlusPerStat.Damage = 30;
            this.PlusStat.cri = 40f; 
            this.PlusStat.atk = 2;
            this.PlusStat.PlusCriDmg = 50; 
            this.PlusStat.HIT_CC = 33;
            this.PlusStat.HIT_DOT = 33;
            this.PlusStat.HIT_DEBUFF = 33;
        }
        public void BattleStart(BattleSystem Ins)
        {
            bool flag = this.BChar.Info.KeyData == "Saber";
            if (flag)
            {
                this.PlusStat.spd += 2;
                this.PlusStat.Penetration += 30f;
                this.BChar.BuffAdd(ModItemKeys.Buff_Saber_yingxiong_B, this.BChar, false, 0, false, -1, false);
            }
        }
    }
}