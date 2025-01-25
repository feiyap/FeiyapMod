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
    /// 鲜血礼赞
    /// 受到<color=purple>痛苦伤害</color>时，有&a几率(&user的暴击率)造成额外50%伤害。
    /// </summary>
    public class B_RemiliaScarlet_3:Buff, IP_DamageTakeChange
    {
        public override void Init()
        {
            base.Init();
        }

        public int DamageTakeChange(BattleChar Hit, BattleChar User, int Dmg, bool Cri, bool NODEF = false, bool NOEFFECT = false, bool Preview = false)
        {
            if (NODEF)
            {
                int prop = (int)this.Usestate_L.GetStat.cri;
                int ran = RandomManager.RandomInt(this.BChar.GetRandomClass().Main, 1, 100);

                if (ran > prop)
                {
                    Dmg = (int)(Dmg * 150 / 100);
                }
            }
            return Dmg;
        }

        public override string DescExtended()
        {
            string username = "蕾米莉亚";
            if (base.Usestate_L != null)
            {
                username = base.Usestate_L.Info.Name;
            }

            return this.BuffData.Description.Replace("&user", username)
                                            .Replace("&a", (this.Usestate_F.GetStat.cri * 1f).ToString());
        }
    }
}