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
namespace KirisameMarisa
{
	/// <summary>
	/// 偶遇霖之助
	/// Button
	/// ButtonToolTip
	/// </summary>
    public class RE_KirisameMarisa_0:RandomEventBaseScript
    {
        public override void UseButton1()
        {
            InventoryManager.Reward(ItemBase.GetItem(new GDESkillData("S_Lucy_16")));
            
            base.EventDisable(base.Orderstrings[0]);
        }

        public override void UseButton2()
        {
            base.UseButton1();
            if (PlayData.Gold >= 2000)
            {
                PlayData.Gold -= 2000;
                InventoryManager.Reward(ItemBase.GetItem("Item_KirisameMarisa_DangerTrigger"));
                base.EventDisable(base.Orderstrings[0]);
                return;
            }
            EffectView.SimpleTextout(this.MyUI.ButtonList[1].transform, ScriptLocalization.UI_RandomEventUI.NeedGold, 1f, false, 1f);
        }
    }
}