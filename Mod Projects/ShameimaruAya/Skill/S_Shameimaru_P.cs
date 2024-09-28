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
namespace ShameimaruAya
{
	/// <summary>
	/// 北风灵
	/// 每使用4次[北风灵]，抽取1个技能。
	/// </summary>
    public class S_Shameimaru_P:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            int count = BattleSystem.instance.BattleLogs.getSkills((BattleLog log) => log.WhoUse.Info.Ally, (Skill skill) => skill.MySkill.KeyID == "S_Shameimaru_P", -1).Count;
            if (count != 0 && count % 4 == 3)
            {
                BattleSystem.instance.AllyTeam.Draw();
            }
        }
    }
}