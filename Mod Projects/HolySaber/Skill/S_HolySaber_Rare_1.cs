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
namespace HolySaber
{
	/// <summary>
	/// 尊荣骑士·维尔伯特
	/// 生成2个[圣骑士]。
	/// <color=#FFA500>进化</color> - 额外获得[防御降临]。
	/// </summary>
    public class S_HolySaber_Rare_1: SkillExtended_HolySaber
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);
            
            {
                Skill tmpSkill = Skill.TempSkill("S_HolySaber_Token", this.BChar, this.BChar.MyTeam);
                BattleSystem.instance.AllyTeam.Add(tmpSkill, true);

                Skill tmpSkill2 = Skill.TempSkill("S_HolySaber_Token", this.BChar, this.BChar.MyTeam);
                BattleSystem.instance.AllyTeam.Add(tmpSkill2, true);
            }
        }
    }
}