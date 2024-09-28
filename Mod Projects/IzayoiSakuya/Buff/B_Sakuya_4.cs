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
	/// 悬滞的飞刃
	/// 当自身被施加干扰减益时，受到%a伤害。
	/// </summary>
    public class B_Sakuya_4:Buff, IP_BuffAdd
    {
        public override string DescInit()
        {
            return base.DescInit().Replace("&a", ((int)(base.Usestate_F.GetStat.atk * 0.75f)).ToString());
        }
        
        public void Buffadded(BattleChar BuffUser, BattleChar BuffTaker, Buff addedbuff)
        {
            if (BuffTaker == this.BChar && addedbuff.BuffData.BuffTag.Key == GDEItemKeys.BuffTag_CrowdControl)
            {
                BattleSystem.DelayInput(this.Damage());
            }
        }
        
        public IEnumerator Damage()
        {
            yield return new WaitForSeconds(0.1f);
            this.BChar.Damage(base.Usestate_F, (int)(base.Usestate_F.GetStat.atk * 0.75f), false, false, false, 0, false, false, false);
            yield break;
        }
    }
}