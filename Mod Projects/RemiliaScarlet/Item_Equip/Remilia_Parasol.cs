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
namespace RemiliaScarlet
{
	/// <summary>
	/// 特别定制的太阳伞
	/// 当装备者给目标施加痛苦或弱化减益时，治疗自己10%最大体力。
	/// </summary>
    public class Remilia_Parasol:EquipBase, IP_BuffAddAfter
    {
        public override void Init()
        {
            base.Init();
            this.PlusPerStat.MaxHP = 30;
            this.PlusStat.HIT_DEBUFF = 10f;
            this.PlusStat.HIT_DOT = 30f;
        }

        // Token: 0x0600332C RID: 13100 RVA: 0x00162124 File Offset: 0x00160324
        public void BuffaddedAfter(BattleChar BuffUser, BattleChar BuffTaker, Buff addedbuff, StackBuff stackBuff)
        {
            if (BuffUser == this.BChar && !BuffTaker.Info.Ally && addedbuff.BuffData.Debuff && (addedbuff.BuffData.BuffTag.Key == GDEItemKeys.BuffTag_Debuff || addedbuff.BuffData.BuffTag.Key == GDEItemKeys.BuffTag_DOT))
            {
                this.BChar.Heal(this.BChar, Misc.PerToNum((float)this.BChar.GetStat.maxhp, 10f), false, false, null);
            }
        }
    }
}