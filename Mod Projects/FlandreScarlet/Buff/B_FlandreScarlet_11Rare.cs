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
namespace FlandreScarlet
{
	/// <summary>
	/// 禁忌孤独
	/// 所有技能都能触发[禁忌欲望]和[禁忌狂乱]的额外效果。
	/// </summary>
    public class B_FlandreScarlet_11Rare: Buff, IP_DamageTakeChange
    {
        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
            this.PlusPerStat.MaxHP = -50;
            this.PlusStat.DeadImmune = 40;
        }

        public override string DescExtended()
        {
            return base.DescExtended().Replace("&a", ((int)(this.BChar.GetStat.maxhp * 0.33)).ToString());
        }

        public int DamageTakeChange(BattleChar Hit, BattleChar User, int Dmg, bool Cri, bool NODEF = false, bool NOEFFECT = false, bool Preview = false)
        {
            if (Dmg > this.BChar.GetStat.maxhp * 0.33)
            {
                Dmg = (int)(this.BChar.GetStat.maxhp * 0.33);
            }
            return Dmg;
        }
    }
}