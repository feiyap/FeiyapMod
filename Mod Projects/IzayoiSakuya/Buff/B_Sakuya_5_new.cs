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
namespace IzayoiSakuya
{
	/// <summary>
	/// 完美空间
	/// 每次触发「月魔术」的额外效果时，抽取1个技能。
	/// </summary>
    public class B_Sakuya_5_new:Buff
    {
        public override void Init()
        {
            base.Init();
            this.PlusStat.cri = 6 * StackNum;
            this.PlusStat.dod = 6 * StackNum;
        }
    }
}