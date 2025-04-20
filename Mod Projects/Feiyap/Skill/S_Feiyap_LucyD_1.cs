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
	/// 于午后的咖啡厅偶遇
	/// 若目标拥有保护体力极限，额外抽取 1 个技能。
	/// </summary>
    public class S_Feiyap_LucyD_1:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);

            BattleSystem.instance.AllyTeam.Draw(2);
            if (Targets[0].GetStat.Strength)
            {
                BattleSystem.instance.AllyTeam.Draw(1);
            }
        }
    }
}