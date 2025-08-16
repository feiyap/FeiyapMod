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
	/// 人偶「未来文乐」
	/// 选择：
	/// - 选择 1 个「人形」技能，立即触发 2 次。
	/// - 选择 1 个「人形」技能，立即强化触发 1 次。
	/// </summary>
    public class S_FAlice_6 : Skill_Extended
    {
        public override void Init()
        {
            base.Init();
            this.ChoiceSkillList = new List<string>();
            this.ChoiceSkillList.Add(ModItemKeys.Skill_S_FAlice_6_0);
            this.ChoiceSkillList.Add(ModItemKeys.Skill_S_FAlice_6_1);
        }
    }
}