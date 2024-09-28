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
namespace Eirin
{
	/// <summary>
	/// 仙香玉兔
	/// 无法行动。
	/// 解除时，优先抽取3个自己的技能。
	/// </summary>
    public class B_Eirin_LucyD:Buff, IP_PlayerTurn
    {
        public override void Init()
        {
            base.Init();
            this.PlusStat.Stun = true;
        }

        public void Turn()
        {
            for (int i = 0; i < 3; i++)
            {
                BattleSystem.instance.AllyTeam.CharacterDraw(this.BChar, null);
            }
            base.SelfDestroy(false);
        }
    }
}