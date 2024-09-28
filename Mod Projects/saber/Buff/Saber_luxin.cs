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
namespace saber
{
	/// <summary>
	/// 龙之炉心
	/// 每回合回复4点生命值并获得1点魔力
	/// </summary>
    public class Saber_luxin:Buff
    {
        public void Turn()
        {
            this.BChar.BuffAdd(ModItemKeys.Buff_Saber_moli, this.BChar, false, 0, false, -1, false);
        }
    }
}