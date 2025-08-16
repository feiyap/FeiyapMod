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
namespace FAlice
{
	/// <summary>
	/// 终符「猎奇剧团座流星雨」
	/// 将所有倒计时中的「人形」技能置入弃牌库。
	/// 将 1 个“试验中「歌莉娅人形」”加入倒计时栏。
	/// </summary>
    public class S_FAlice_Rare_3 : Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);
            List<SkillExtended_FAlice> dolls = new List<SkillExtended_FAlice>();
            foreach (CastingSkill castingSkill in BattleSystem.instance.CastSkills)
            {
                SkillExtended_FAlice se = castingSkill.skill.ExtendedFind<SkillExtended_FAlice>();
                if (se != null) dolls.Add(se);
            }
            foreach (SkillExtended_FAlice doll in dolls)
            {
                doll.CastingWaste();
            }

            Skill skill = Skill.TempSkill(ModItemKeys.Skill_S_FAlice_Rare_3_0, this.BChar, this.BChar.MyTeam);
            BattleSystem.DelayInput(BattleSystem.instance.SkillRandomUseIenum(this.BChar, skill, false, true, false));
        }
    }
}