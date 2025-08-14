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
namespace Phrolova
{
	/// <summary>
	/// 八重奏
	/// 暴击率提升&a%(&user攻击力的100%)。
	/// 自己造成的<color=purple>痛苦伤害</color>可以暴击。
	/// </summary>
    public class B_Phrolova_5:Buff, IP_DamageCriCheck
    {
        public override void Init()
        {
            base.Init();
            this.PlusStat.cri = (int)(this.Usestate_F.GetStat.atk * 1f);
            this.OnePassive = true;
        }

        public void DamageCriCheck(BattleChar Hit, BattleChar User, int Dmg, ref bool Cri, bool Pain, bool NOEFFECT = false)
        {
            if (Pain && User == this.BChar && !Hit.Info.Ally)
            {
                float num = 0f;
                num = User.GetStat.cri;
                if (RandomManager.RandomPer(User.GetRandomClass().DamageCri, 100, (int)(num + (float)Hit.GetStat.crihit)))
                {
                    Cri = true;
                }
            }
        }

        public override string DescExtended()
        {
            return this.BuffData.Description.Replace("&a", ((int)(this.Usestate_F.GetStat.atk * 1f)).ToString())
                                            .Replace("&user", this.Usestate_F.Info.Name);
        }
    }
}