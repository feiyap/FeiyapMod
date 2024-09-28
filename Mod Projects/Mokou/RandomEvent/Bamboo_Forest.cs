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
	/// 迷途竹林
	/// 一片茂密的竹林，竹子都倾斜地生长着。扭曲之地里怎么会有怎么一片竹林存在？
	/// Button
	/// 跟着圆月的指引，往面向月亮的方向前行。
	/// 跟着圆月的指引，往背离月亮的方向前行。
	/// 妹红：“这里是，迷途竹林？我对这里熟，就让我来带路吧”
	/// ButtonToolTip
	/// </summary>
    public class Bamboo_Forest:RandomEventBaseScript
    {
        public override void EventInit()
        {
            base.EventInit();
            Mokou_isTeam = false;
            for (int i = 0; i < PlayData.TSavedata.Party.Count; i++)
            {
                if (PlayData.TSavedata.Party[i].KeyData == "Mokou")
                {
                    Mokou_isTeam = true;
                    return;
                }
            }
        }
        public override void EventOpen()
        {
            base.EventOpen();
            if(Mokou_isTeam && PlayData.TSavedata.BossClear)
            {
                return;
            }
            this.ButtonOff(2);
        }
        public override void UseButton1()
        {
            this.MainEvent(0, 0);
        }
        public override void UseButton2()
        {
            this.MainEvent(1, 1);
        }
        public override void UseButton3()
        {
            this.MainEvent(2, 2);
        }
        public void MainEvent(int Num, int button_index)
        {
            switch (Num)
            {
                case 0:
                    InventoryManager.Reward(ItemBase.GetItem("Mokou_Legacy"));
                    base.ChangeDesc(base.Orderstrings[0], true);
                    break;
                case 1:
                    InventoryManager.Reward(ItemBase.GetItem(GDEItemKeys.Item_Consume_Celestial));
                    base.ChangeDesc(base.Orderstrings[1], true);
                    break;
                case 2:
                    base.ChangeDesc(base.Orderstrings[2], true);
                    break;
            }
            base.EventDisable();
        }
        public bool Mokou_isTeam;
    }
}