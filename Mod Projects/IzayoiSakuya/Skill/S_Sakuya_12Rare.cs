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
	/// 银符「完美女仆」
	/// </summary>
    public class S_Sakuya_12Rare:Skill_Extended, IP_SkillCastingStart, IP_SkillCastingQuit
    {
        public void SkillCasting(CastingSkill ThisSkill)
        {
            this.BChar.BuffAdd("B_Sakuya_12Rare", this.BChar, false, 0, false, -1, false);
        }

        public void SkillCastingQuit(CastingSkill ThisSkill)
        {
            this.BChar.BuffReturn("B_Sakuya_12Rare")?.SelfDestroy();
        }
    }
}