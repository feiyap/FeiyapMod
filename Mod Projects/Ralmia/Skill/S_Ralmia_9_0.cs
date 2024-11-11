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
	/// 典范转移
	/// 持有在手上时，每打出1张创造物技能，减少1点费用。
	/// 选择-从[守御的创造物] [锋锐的创造物] [迅袭的创造物] 中选1张打出。
	/// </summary>
    public class S_Ralmia_9_0:Skill_Extended, IP_SkillUse_Team
    {
        public int UseNum;

        public override void Init()
        {
            base.Init();
            this.UseNum = 0;
            this.ChoiceSkillList = new List<string>();
            this.ChoiceSkillList.Add("S_Ralmia_9_1");
            this.ChoiceSkillList.Add("S_Ralmia_9_2");
            this.ChoiceSkillList.Add("S_Ralmia_9_3");
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            this.APChange = -this.UseNum;
        }

        public void SkillUseTeam(Skill skill)
        {
            /*
            if (skill.MySkill.KeyID == "S_Ralmia_0" || skill.MySkill.KeyID == "S_Ralmia_1" ||
                skill.MySkill.KeyID == "S_Ralmia_2" || skill.MySkill.KeyID == "S_Ralmia_3" ||
                skill.MySkill.KeyID == "S_Ralmia_9_0" || skill.MySkill.KeyID == "S_Ralmia_10Rare" ||
                skill.MySkill.KeyID == "S_Ralmia_12" ||
                skill.MySkill.KeyID == "S_Ralmia_13Rare" || skill.MySkill.KeyID == "S_Ralmia_13Rare_0" ||
                skill.MySkill.KeyID == "S_Ralmia_13Rare_1" || skill.MySkill.KeyID == "S_Ralmia_13Rare_2")
                */
            if (skill.ExtendedFind_DataName("SkillEn_Ralmia_2") != null)
            {
                this.UseNum++;
            }
        }

        public override void DiscardSingle(bool Click)
        {
            BattleSystem.instance.AllyTeam.Draw();
            base.DiscardSingle(Click);
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            this.UseNum = 0;
        }
    }
}