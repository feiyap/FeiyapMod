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
    /// 无敌
    /// 本回合免疫一次伤害
    /// </summary>
    public class Saber_wudi : Buff
    {
        public override void Init()
        {
            this.PlusStat.invincibility = true;
            base.Init();
        }
    }
}