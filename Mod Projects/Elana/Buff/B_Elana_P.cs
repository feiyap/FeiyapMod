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
namespace Elana
{
	/// <summary>
	/// 耶拉的祈祷
	/// </summary>
    public class B_Elana_P:Buff
    {
        public override void Init()
        {
            base.Init();
            this.PlusStat.atk = BattleSystem.instance.GetBattleValue<BV_Elana_P>().count;
            this.PlusStat.maxhp = BattleSystem.instance.GetBattleValue<BV_Elana_P>().count;
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            this.PlusStat.atk = BattleSystem.instance.GetBattleValue<BV_Elana_P>().count;
            this.PlusStat.maxhp = BattleSystem.instance.GetBattleValue<BV_Elana_P>().count;
        }
    }
}