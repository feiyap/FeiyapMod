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
namespace HiHouClab
{
	/// <summary>
	/// 旧世界的冒险酒馆
	/// 若此技能为固定能力，则释放后恢复 1 点法力值。
	/// 选择：
	/// - 选择 1 个倒计时中的技能，使其立即释放。
	/// - 选择 1 个倒计时中的技能，使其倒计时+2。
	/// - 选择 1 个倒计时中的技能，使其倒计时-2。
	/// </summary>
    public class S_Maribel_7:Skill_Extended
    {
        public override void Init()
        {
            base.Init();
            this.ChoiceSkillList = new List<string>();
            this.ChoiceSkillList.Add("S_Maribel_7_1");
            this.ChoiceSkillList.Add("S_Maribel_7_2");
            this.ChoiceSkillList.Add("S_Maribel_7_3");
        }
    }
}