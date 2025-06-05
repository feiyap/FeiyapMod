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
namespace PatchouliKnowledge
{
	/// <summary>
	/// 石至名归
	/// 回合结束时减少 1 层。
	/// </summary>
    public class B_Pachi_4_4:Buff, IP_DamageTakeChange
    {
        public override void Init()
        {
            base.Init();
            this.PlusStat.Strength = true;
        }

        public int DamageTakeChange(BattleChar Hit, BattleChar User, int Dmg, bool Cri, bool NODEF = false, bool NOEFFECT = false, bool Preview = false)
        {
            if (Hit == this.BChar && !Preview)
            {
                Dmg -= Dmg * (int)this.Usestate_F.GetStat.def * 5 / 1000;
                this.SelfStackDestroy();
            }

            return Dmg;
        }

        public override string DescExtended()
        {
            return this.BuffData.Description.Replace("&user", this.Usestate_F.Info.Name)
                                            .Replace("&a", ((int)this.Usestate_F.GetStat.def * 0.5).ToString());
        }
    }
}