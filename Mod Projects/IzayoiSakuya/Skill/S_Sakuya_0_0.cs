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
namespace IzayoiSakuya
{
	/// <summary>
	/// 时符「调换魔法」
	/// 将1个技能放在手牌顶或手牌底。
	/// </summary>
    public class S_Sakuya_0_0: Skill_Extended
    {
        public override void Init()
        {
            base.Init();
            this.ChoiceSkillList = new List<string>();
            this.ChoiceSkillList.Add("S_Sakuya_0_1");
            this.ChoiceSkillList.Add("S_Sakuya_0_2");
        }

        public override void DiscardSingle(bool Click)
        {
            BattleSystem.instance.AllyTeam.Draw();
            P_IzayoiSakuya.getTimeKnife(this.BChar, 1);
            base.DiscardSingle(Click);
        }
    }
}