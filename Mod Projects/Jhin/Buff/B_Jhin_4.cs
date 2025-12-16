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
namespace Jhin
{
	/// <summary>
	/// 穿帮
	/// 无法指定其他角色。
	/// </summary>
    public class B_Jhin_4:Buff
    {
        public override void Init()
        {
            base.Init();
            this.PlusStat.crihit = 44;
        }
    }
}