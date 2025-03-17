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
namespace FFAce
{
	/// <summary>
	/// 翻牌强化
	/// 下次使用固定能力时可额外查看&a个技能，并触发相应的[翻开]效果。
	/// </summary>
    public class B_FFAce_LucyD:Buff
    {
        public override string DescExtended()
        {
            return base.DescExtended().Replace("&a", this.StackNum.ToString());
        }
    }
}