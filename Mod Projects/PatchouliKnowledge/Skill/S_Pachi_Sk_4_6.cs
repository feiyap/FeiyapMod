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
namespace PatchouliKnowledge
{
	/// <summary>
	/// 月土符「阿波罗12号」
	/// 每次使用手中的技能时减少 1 点费用。
	/// </summary>
    public class S_Pachi_Sk_4_6:Skill_Extended, IP_SkillUse_Team
    {
        public override void Init()
        {
            base.Init();
            this.UseNum = 0;
        }

        public override void FixedUpdate()
        {
            this.APChange = -this.UseNum;
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            this.UseNum = 0;
        }

        public void SkillUseTeam(Skill skill)
        {
            this.UseNum++;
        }

        public int UseNum;
    }
}