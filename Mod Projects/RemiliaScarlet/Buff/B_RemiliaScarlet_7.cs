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
    /// 狂血之吻
    /// 攻击力提升&a点(&user最大体力值的10%)。
    /// </summary>
    public class B_RemiliaScarlet_7:Buff
    {
        public override void Init()
        {
            base.Init();
            this.PlusStat.Strength = true;
            this.PlusStat.maxhp = 5;
        }

        public override void BuffStat()
        {
            base.BuffStat();

            PlusStat.atk = 1 + this.Usestate_F.GetStat.maxhp * 0.05f;
        }

        public override string DescExtended()
        {
            string username = "蕾米莉亚";
            if (base.Usestate_L != null)
            {
                username = base.Usestate_L.Info.Name;
            }

            return this.BuffData.Description.Replace("&user", username)
                                            .Replace("&a", ((int)(1 + this.Usestate_F.GetStat.maxhp * 0.05f)).ToString());
        }
    }
}