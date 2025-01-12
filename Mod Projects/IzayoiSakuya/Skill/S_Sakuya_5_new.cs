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
	/// 时符「完美空间」
	/// </summary>
    public class S_Sakuya_5_new:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            Skill tmpSkill = Skill.TempSkill("S_Sakuya_0_0", this.BChar, this.BChar.MyTeam);
            BattleSystem.instance.AllyTeam.Add(tmpSkill, true);

            if (Targets[0] != this.BChar)
            {
                if (BattleSystem.instance.GetBattleValue<BV_Sakuya_TKnife>() == null)
                {
                    BattleSystem.instance.BattleValues.Add(new BV_Sakuya_TKnife());
                }
                
                int count = BattleSystem.instance.GetBattleValue<BV_Sakuya_TKnife>().KnifeList[this.BChar];
                P_IzayoiSakuya.getTimeKnife(this.BChar, -count);
                P_IzayoiSakuya.getTimeKnife(Targets[0], count);

                Targets[0].MyTeam.BasicSkillRefill(Targets[0], Targets[0].BattleBasicskillRefill);
            }
        }
    }
}