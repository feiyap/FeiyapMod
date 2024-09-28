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
namespace ShameimaruAya
{
	/// <summary>
	/// 操纵风程度的能力
	/// </summary>
    public class B_Shameimaru_P:Buff
    {
        public override void Init()
        {
            this.PlusStat.cri = 5 * StackNum;
        }
    }
}