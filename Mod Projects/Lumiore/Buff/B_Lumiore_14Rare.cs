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
namespace Lumiore
{
	/// <summary>
	/// 背水一战
	/// 保护体力极限，受到的伤害转变为0。
	/// </summary>
    public class B_Lumiore_14Rare:Buff
    {
        public override void Init()
        {
            base.Init();
            this.PlusStat.Strength = true;
            this.PlusStat.invincibility = true;
        }
    }
}