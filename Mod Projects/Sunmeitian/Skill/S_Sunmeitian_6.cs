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
namespace Sunmeitian
{
	/// <summary>
	/// 七十二变
	/// 倒计时期间，获得100%伤害减免。
	/// 释放时抽取1个技能。
	/// </summary>
    public class S_Sunmeitian_6:Skill_Extended, IP_SkillCastingStart
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);
            BattleSystem.instance.AllyTeam.Draw();
        }

        public void SkillCasting(CastingSkill ThisSkill)
        {
            this.BChar.BuffAdd("B_RemiliaScarlet_4", this.BChar, false, 0, false, -1, false);
        }
    }
}