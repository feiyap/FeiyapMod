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
	/// 幽梦之苏醒
	/// 战斗开始的前3个回合内获得额外2点攻击力和50%防御穿透。
	/// </summary>
    public class E_YuyukoF_1:EquipBase, IP_PlayerTurn
    {
        public override void Init()
        {
            base.Init();
            this.PlusStat.atk = 4;
            this.PlusStat.Penetration = 50f;
        }

        public void Turn()
        {
            if (BattleSystem.instance.TurnNum == 1)
            {
                this.BChar.BuffAdd("B_E_YuyukoF_1", this.BChar);
            }
        }
    }
}