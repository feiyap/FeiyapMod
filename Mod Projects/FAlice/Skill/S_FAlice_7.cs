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
namespace FAlice
{
	/// <summary>
	/// 战符「小小军势」
	/// 选择：
	/// - 在手中随机生成 2 个不同的「人形」技能。
	/// - 在手中生成 1 个指定的「人形」技能。
	/// </summary>
    public class S_FAlice_7 : Skill_Extended
    {
        public override void Init()
        {
            base.Init();
            this.ChoiceSkillList = new List<string>();
            this.ChoiceSkillList.Add(ModItemKeys.Skill_S_FAlice_7_0);
            this.ChoiceSkillList.Add(ModItemKeys.Skill_S_FAlice_7_1);
        }
    }
}