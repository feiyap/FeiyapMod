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
	/// 英雄作成
	/// 不列颠传说中的王。也被誉为骑士王。阿尔托莉雅是幼名，自从当上国王之后，就开始被称为亚瑟王了。在骑士道凋零的时代，手持圣剑，给不列颠带来了短暂的和平与最后的繁荣。
	/// </summary>
    public class Saber_yingxiong_B:Buff
    {
        public override void Init()
        {
            base.Init();
            this.PlusStat.atk = (int)(float)(1 * base.StackNum);
            this.PlusStat.cri = (float)(2 * base.StackNum);
            this.PlusStat.def = (float)(5 * base.StackNum);
            this.PlusStat.PlusCriDmg = (float)(5 * base.StackNum);
            this.PlusPerStat.MaxHP = (int)(float)(6 * base.StackNum);
        }
    }
}