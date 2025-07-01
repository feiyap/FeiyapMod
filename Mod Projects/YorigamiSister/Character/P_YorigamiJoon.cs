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
using EOS;
using EOS.Attributes;
using EOS.Tools;
namespace YorigamiSister
{
	/// <summary>
	/// 依神女苑
	/// Passive:
	/// 使人消耗财产程度的能力 - 每消耗100金币，使自身永久提升1%暴击率和0.5%暴击伤害。
	/// 在篝火处可以消耗1200金币为依神女苑购买额外的装备栏。
	/// 今宵是飘逸的利己主义者 - 使用点金卷轴时，额外获得50%金币。
	/// </summary>
    public class P_YorigamiJoon:Passive_Char
    {
        public static int costGold = 0;

        public override void Init()
        {
            base.Init();
            costGold = 0;
            EOSManager.AddListener(new GoldChangeListener());
        }
    }

    public class GoldChangeFunction : IEventListener
    {
        [EventListener(typeof(Gold_Event))]
        public virtual void GoldChange(int num)
        {

        }
    }

    public class GoldChangeListener : GoldChangeFunction
    {
        public override void GoldChange(int num)
        {
            Debug.Log(num);
            if (num < 0)
            {
                P_YorigamiJoon.costGold -= num;
            }
            Debug.Log("costGold=");
            Debug.Log(P_YorigamiJoon.costGold);
        }
    }
}