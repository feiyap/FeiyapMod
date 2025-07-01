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
namespace FeiyapBoss
{
	/// <summary>
	/// 热寂
	/// 每次触发时，使这个减益的每回合伤害量提升10点。
	/// 被抵抗时，立即阵亡。
	/// </summary>
    public class B_Feiyap_Boss_5:Buff
    {
        public override void TurnUpdate()
        {
            base.TurnUpdate();
            this.PlusDamageTick += 5;
        }
    }
}