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
using BasicMethods;
namespace Yuyuko
{
	/// <summary>
	/// 再迷「幻想乡的黄泉归」
	/// 握在手中时，每次有技能被放逐，使这个技能费用降低1点。
	/// </summary>
    public class S_YuyukoF_Rare_2:Skill_Extended, IP_OnSkillExcept
    {
        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
        }

        public bool OnSkillExcept(Dictionary<Skill, SkillLocation> exceptSkills)
        {
            this.APChange -= 1;

            return true;
        }
    }
}