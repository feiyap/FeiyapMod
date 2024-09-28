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
	/// 幻幽「迷幻的杰克」
	/// </summary>
    public class S_Sakuya_3_1:Skill_Extended, IP_SkillCastingStart
    {
        public void SkillCasting(CastingSkill ThisSkill)
        {
            ThisSkill.Target.BuffAdd("B_Sakuya_3", this.BChar, false, 0, false, 1, false);
        }

        public override string DescExtended(string desc)
        {
            return base.DescExtended(desc).Replace("%a", ((int)(this.BChar.GetStat.atk * 1.0f)).ToString()).Replace("%b", ((int)(this.BChar.GetStat.atk * 0.2f)).ToString());
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            BattleSystem.instance.AllyTeam.Draw();
        }
    }
}