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
namespace YasakaKanano
{
	/// <summary>
	/// 神秘「Yamato Torus」
	/// 每次使用手中的技能时，费用降低1点。
	/// 生成2个[西风灵]。
	/// </summary>
    public class S_Kanano_8:Skill_Extended, IP_SkillUse_Team
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

            Skill tmpSkill = Skill.TempSkill("S_Kanano_P", this.BChar, this.BChar.MyTeam);
            BattleSystem.instance.AllyTeam.Add(tmpSkill, true);
            Skill tmpSkill2 = Skill.TempSkill("S_Kanano_P", this.BChar, this.BChar.MyTeam);
            BattleSystem.instance.AllyTeam.Add(tmpSkill2, true);
        }

        public void SkillUseTeam(Skill skill)
        {
            this.UseNum++;
        }

        public int UseNum;
    }
}