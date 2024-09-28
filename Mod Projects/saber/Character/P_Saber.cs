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
	/// 阿尔托莉雅
	/// Passive:
	/// </summary>
    public class P_Saber: Passive_Char,IP_PlayerTurn, IP_BattleStart_Ones, IP_BuffAddAfter
    {
        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
        }// Token: 0x060000D5 RID: 213 RVA: 0x00006304 File Offset: 0x00004504
        public void BuffaddedAfter(BattleChar BuffUser, BattleChar BuffTaker, Buff addedbuff, StackBuff stackBuff)
        {
            bool flag = BuffTaker == this.BChar && addedbuff.BuffData.Key == "Saber_jinsheng";
            if (flag)
            {
                foreach (IP_SCUpdate ip_SCUpdate in Ex_Saber_jiefang.GetAll_IP_InBattle<IP_SCUpdate>())
                {
                    if (ip_SCUpdate != null)
                    {
                        ip_SCUpdate.SCUpdate(BuffTaker, addedbuff);
                    }
                }
            }
        }
        public void Turn()
        {
           this.BChar.BuffAdd(ModItemKeys.Buff_Saber_moli, this.BChar, false, 0, false, -1, false);
        }
        public void BattleStart(BattleSystem Ins)
        {
           this.BChar.BuffAdd(ModItemKeys.Buff_SaberBuff, this.BChar, false, 0, false, -1, false);
        }

    }
}