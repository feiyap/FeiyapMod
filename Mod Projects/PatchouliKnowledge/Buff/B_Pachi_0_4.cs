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
	/// 巨石护卫
	/// 抵挡友军未能抵抗的干扰减益或弱化减益。触发后，或受到&a点伤害(&user防御力的50%)后减少 1 层。
	/// </summary>
    public class B_Pachi_0_4:Buff, IP_DamageTake
    {
        public void DamageTake(BattleChar User, int Dmg, bool Cri, ref bool resist, bool NODEF = false, bool NOEFFECT = false, BattleChar Target = null)
        {
            if (Target == this.BChar)
            {
                if (Dmg >= (this.Usestate_F.GetStat.def * 0.5))
                {
                    this.SelfStackDestroy();
                }
            }
        }

        public override string DescExtended()
        {
            return this.BuffData.Description.Replace("&user", this.Usestate_F.Info.Name)
                                            .Replace("&a", ((int)this.Usestate_F.GetStat.def * 0.5).ToString());
        }
    }
}