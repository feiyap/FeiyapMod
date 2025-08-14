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
	/// 亡灵序曲
	/// 受到的<color=purple>痛苦伤害</color>提升&a%<color=#FF7A33>(&user攻击力的100%)</color>。
	/// </summary>
    public class B_Phrolova_3:Buff, IP_DamageTakeChange
    {
        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
        }

        public int DamageTakeChange(BattleChar Hit, BattleChar User, int Dmg, bool Cri, bool NODEF = false, bool NOEFFECT = false, bool Preview = false)
        {
            if (NODEF)
            {
                Dmg += (int)(Dmg * (this.Usestate_F.GetStat.atk / 50));
            }

            return Dmg;
        }

        public override string DescExtended()
        {
            string username = "";
            if (BattleSystem.instance != null)
            {
                username = this.BChar.Info.Name;
            }

            return this.BuffData.Description.Replace("&a", ((int)(this.Usestate_F.GetStat.atk * 2f)).ToString())
                                            .Replace("&user", username);
        }
    }
}