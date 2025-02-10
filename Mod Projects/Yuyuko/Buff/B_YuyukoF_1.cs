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
namespace Yuyuko
{
	/// <summary>
	/// 轮回蝶
	/// 结算时降低&a最大体力值(&user的攻击力的50%)。
	/// </summary>
    public class B_YuyukoF_1:Buff
    {
        public override void TurnUpdate()
        {
            base.TurnUpdate();

            BattleSystem.instance.GetBattleValue<BV_YuyukoF_P>().setDieList(this.BChar, (int)(this.Usestate_F.GetStat.atk * 0.5f), this.Usestate_F);
        }

        public override string DescExtended()
        {
            return base.DescExtended().Replace("&user", this.Usestate_F.Info.Name)
                                      .Replace("&a", ((int)(this.Usestate_F.GetStat.atk * 0.5f)).ToString());
        }
    }
}