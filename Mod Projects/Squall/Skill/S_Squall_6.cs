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
namespace Squall
{
	/// <summary>
	/// 静寂裁决
	/// 消耗1层刃甲，选择：
	/// - 使1个敌人将会最先释放的攻击技能立即释放，斯考尔替友军承受此技能的总伤害量。
	/// - 使1个敌人本回合中将会最先释放的1个攻击技能延后1回合。
	/// </summary>
    public class S_Squall_6:Skill_Extended
    {
        public override void Init()
        {
            base.Init();
            this.ChoiceSkillList = new List<string>();
            this.ChoiceSkillList.Add("S_Squall_6_1");
            this.ChoiceSkillList.Add("S_Squall_6_2");
        }
    }
}