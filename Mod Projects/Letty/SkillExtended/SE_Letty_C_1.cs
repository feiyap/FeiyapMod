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
namespace Letty
{
	/// <summary>
	/// 使 1 个随机敌人冻僵 1 回合。
	/// 一次性技能
	/// </summary>
    public class SE_Letty_C_1:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            BattleSystem.instance.EnemyList.Random(this.BChar.GetRandomClass().Main).BuffAdd("B_Letty_P_1", this.BChar, false, 150, false, 1, false);
        }

        public override bool CanSkillEnforce(Skill MainSkill)
        {
            return MainSkill.Disposable;
        }
    }
}