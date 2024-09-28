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
namespace Mokou
{
	/// <summary>
	/// 绀珠之药
	/// 瓶子中装着不明颜色的药水，据说喝下只会就可以预见未来，规避死亡的结局。
	/// </summary>
    public class Mokou_Legacy:PassiveItemBase, IP_BattleStart_Ones, IP_DamageTake
    {
        public override void Init()
        {
            base.Init();
            this.MyItem.IsUseStack = true;
            this.MyItem.UseStackNum = 2;
            this.NoActiveBattleend = true;
        }
        public void BattleStart(BattleSystem Ins)
        {
            this.MyItem.IsUseStack = true;
            this.MyItem.UseStackNum = 2;
            this.NoActiveBattleend = true;
        }
        public void DamageTake(BattleChar User, int Dmg, bool Cri, ref bool resist, bool NODEF = false,
          bool NOEFFECT = false, BattleChar Target = null)
        {
            if (PlayData.Passive.Find((Item_Passive a) => a.itemkey == GDEItemKeys.Item_Passive_LastFlame) != null)
            {
                if (PlayData.Passive.Find((Item_Passive a) => a.itemkey == GDEItemKeys.Item_Passive_LastFlame).UseStackNum > 0 && Target.BuffFind(GDEItemKeys.Buff_B_Neardeath, false))
                {
                    PlayData.Passive.Find((Item_Passive a) => a.itemkey == GDEItemKeys.Item_Passive_LastFlame).UseStackNum -= 1;
                    base.ShinyEffect();
                    resist = true;
                }
            }
            if (PlayData.Passive.Find((Item_Passive a) => a.itemkey == GDEItemKeys.Item_Passive_LastFlame).UseStackNum == 0)
            {
                base.Deactiveitem = true;
            }
        }
    }
}