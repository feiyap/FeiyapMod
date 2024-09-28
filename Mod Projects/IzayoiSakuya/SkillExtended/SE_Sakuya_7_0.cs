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
    /// 吾刃回归
    /// 释放后回到牌堆顶。
    /// </summary>
    public class SE_Sakuya_7_0:Skill_Extended
    {
        public override void Init()
        {
            base.Init();
            this.NotCount = true;
            this.APChange = -1;
        }
    }
}