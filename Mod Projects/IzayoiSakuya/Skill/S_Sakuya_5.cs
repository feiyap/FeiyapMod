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
	/// 倒计时期间，自身仅有1次，受到伤害时，使所受的伤害变为0，随后对随机敌人造成%a伤害。
	/// </summary>
    public class S_Sakuya_5:Skill_Extended, IP_SkillCastingStart
    {
        public void SkillCasting(CastingSkill ThisSkill)
        {
            this.BChar.BuffAdd("B_Sakuya_5", this.BChar, false, 0, false, 1, false);
        }

        public override string DescExtended(string desc)
        {
            return base.DescExtended(desc).Replace("%a", ((int)(this.BChar.GetStat.atk * 1.65f)).ToString());
        }
    }
}