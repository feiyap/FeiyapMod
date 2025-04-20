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
namespace Feiyap
{
	/// <summary>
	/// 血似刃流
	/// 回合结束时，移除 1 层增益效果。
	/// </summary>
    public class B_Feiyap_0:Buff, IP_TurnEnd
    {
        public override void Init()
        {
            base.Init();
            this.PlusStat.Strength = true;
        }

        public void TurnEnd()
        {
            SelfStackDestroy();
        }
    }
}