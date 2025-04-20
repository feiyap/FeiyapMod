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
namespace Feiyap
{
	/// <summary>
	/// 未完成的一文字
	/// 选择 - 自身获得 1 层“血似刃流”；
	/// 对目标施加 1 层“体内灼烧”。
	/// </summary>
    public class S_Feiyap_2:Skill_Extended
    {
        public override void Init()
        {
            base.Init();
            this.ChoiceSkillList = new List<string>();
            this.ChoiceSkillList.Add("S_Feiyap_2_1");
            this.ChoiceSkillList.Add("S_Feiyap_2_2");
        }
    }
}