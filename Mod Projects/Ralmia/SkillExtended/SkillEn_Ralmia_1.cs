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
namespace Ralmia
{
	/// <summary>
	/// 生命量产
	/// 选择手中的一个创造物技能，使其费用减少1点。
	/// 创造物
	/// </summary>
    public class SkillEn_Ralmia_1:Skill_Extended
    {
        public override void Init()
        {
            base.Init();
            this.APChange = -1;
        }
    }
}