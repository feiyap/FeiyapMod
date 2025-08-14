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
namespace FairyLancelot
{
	/// <summary>
	/// 你已无法离开我
	/// &user获得自身一半的攻击力。
	/// 回合结束时，若本回合&user受到过自身伤害，获得伤害量40%的保护罩。
	/// 被&user击杀时，获得 2 灵魂石，增加 2 点好感度。
	/// </summary>
    public class B_FLancelot_3:Buff, IP_TurnEnd, IP_Awake
    {
        public int dmg = 0;

        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
            dmg = 0;
        }

        public void Awake()
        {
            this.Usestate_L.BuffAdd("B_FLancelot_3_0", this.Usestate_L);
        }

        public void DamageTake(BattleChar User, int Dmg, bool Cri, ref bool resist, bool NODEF = false, bool NOEFFECT = false, BattleChar Target = null)
        {
            if (User == this.Usestate_L && Dmg > 0)
            {
                dmg += Dmg;
            }
            if (User == this.Usestate_L && Dmg >= this.BarrierHP)
            {
                InventoryManager.Reward(ItemBase.GetItem(GDEItemKeys.Item_Misc_Soul, 2));
                PlayData.TSavedata.GetCustomValue<CV_FairyLancelotGood>().heartPoint += 2;
            }
        }

        public void TurnEnd()
        {
            if (dmg > 0)
            {
                this.Usestate_L.BuffAdd("B_FLancelot_Barrier", this.BChar).BarrierHP += dmg;
                dmg = 0;
            }
        }

        public override string DescExtended()
        {
            string username = "兰斯洛特";
            if (base.Usestate_L != null)
            {
                username = base.Usestate_L.Info.Name;
            }

            return this.BuffData.Description.Replace("&user", username);
        }
    }
}