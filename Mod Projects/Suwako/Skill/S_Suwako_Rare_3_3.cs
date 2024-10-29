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
namespace Suwako
{
	/// <summary>
	/// 蛙符「涂有鲜血的赤蛙塚」
	/// </summary>
    public class S_Suwako_Rare_3_3:Skill_Extended
    {
        public override void Init()
        {
            base.Init();
            this.ChoiceSkillList = new List<string>();
            this.ChoiceSkillList.Add("S_Suwako_Rare_3_1");
            this.ChoiceSkillList.Add("S_Suwako_Rare_3_2");
        }
    }
}