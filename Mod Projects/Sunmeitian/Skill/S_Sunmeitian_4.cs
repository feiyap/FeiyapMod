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
namespace Sunmeitian
{
	/// <summary>
	/// 丛林之舞
	/// 选择 - 使所有敌人行动倒计时+1；
	/// 或使所有敌人行动倒计时-1。
	/// 将1张[乾坤之跃]加入手中。
	/// </summary>
    public class S_Sunmeitian_4:Skill_Extended
    {
        public override void Init()
        {
            base.Init();
            this.ChoiceSkillList = new List<string>();
            this.ChoiceSkillList.Add("S_Sunmeitian_4_0");
            this.ChoiceSkillList.Add("S_Sunmeitian_4_1");
        }
    }
}