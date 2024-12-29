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
	/// 黑白魔法使的帽子
	/// 战斗开始时，使所有调查员第一次攻击必定暴击，且这次暴击伤害+100%。
	/// </summary>
    public class R_KirisameMarisa_0:PassiveItemBase, IP_BattleStart_Ones
    {
        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
        }

        public void BattleStart(BattleSystem Ins)
        {
            for (int i = 0; i < BattleSystem.instance.AllyList.Count; i++)
            {
                BattleSystem.instance.AllyList[i].BuffAdd("B_KirisameMarisa_P_1", BattleSystem.instance.AllyList[i], false, 0, false, -1, false);
                BattleSystem.instance.AllyList[i].BuffAdd("B_KirisameMarisa_P_1", BattleSystem.instance.AllyList[i], false, 0, false, -1, false);
                BattleSystem.instance.AllyList[i].BuffAdd("B_KirisameMarisa_P_1", BattleSystem.instance.AllyList[i], false, 0, false, -1, false);
                BattleSystem.instance.AllyList[i].BuffAdd("B_KirisameMarisa_P_1", BattleSystem.instance.AllyList[i], false, 0, false, -1, false);
            }
        }
    }
}