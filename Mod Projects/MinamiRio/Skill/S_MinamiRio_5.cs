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
namespace MinamiRio
{
	/// <summary>
	/// 箭越
	/// 选择 - 使所有敌人行动倒计时+1；
	/// 使所有敌人行动倒计时-1。
	/// 那之后，对行动倒计时最低的敌人造成&a(50%)伤害，抽取1个技能，使自身切换<color=#48D1CC>单弓</color>/<color=#FFD700>和弓</color>状态。
	/// </summary>
    public class S_MinamiRio_5:Skill_Extended
    {
        public override void Init()
        {
            base.Init();
            this.ChoiceSkillList = new List<string>();
            this.ChoiceSkillList.Add("S_MinamiRio_5_0");
            this.ChoiceSkillList.Add("S_MinamiRio_5_1");
        }

        public override string DescExtended(string desc)
        {
            return base.DescExtended(desc).Replace("&a", ((int)(this.BChar.GetStat.atk * 0.5f)).ToString());
        }
    }
}