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
namespace PatchouliKnowledge
{
	/// <summary>
	/// 卫星向日葵
	/// 本次战斗期间最大法力值增加1点。
	/// </summary>
    public class B_Pachi_1_6:Buff
    {
        public override void Init()
        {
            base.Init();
            this.PlusStat.MPR = StackNum;
        }
    }
}