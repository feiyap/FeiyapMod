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
	/// 快照
	/// </summary>
    public class SE_Shameimaru_8:Skill_Extended
    {
        public override void Init()
        {
            base.Init();
            this.APChange = -99;
            this.NotCount = true;
        }
    }
}