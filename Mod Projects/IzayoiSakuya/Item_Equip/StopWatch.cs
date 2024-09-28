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
namespace IzayoiSakuya
{
	/// <summary>
	/// 时停怀表
	/// </summary>
    public class StopWatch:EquipBase, IP_DamageTake, IP_BattleStart_Ones
    {
        public override void Init()
        {
            base.Init();
            this.PlusStat.HIT_CC = 20f;
            this.PlusStat.dod = 20f;
        }

        public void BattleStart(BattleSystem Ins)
        {
            Effect = false;
        }

        public void DamageTake(BattleChar User, int Dmg, bool Cri, ref bool resist, bool NODEF = false, bool NOEFFECT = false, BattleChar Target = null)
        {
            if (!this.Effect && this.BChar.Info.Hp <= 0)
            {
                resist = true;
                Effect = true;
            }
        }

        public bool Effect;
    }
}