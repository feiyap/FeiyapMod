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
namespace HatsuneMiku
{
	/// <summary>
	/// ローリンガール
	/// 施加5层[未来之音]。
	/// 音弦12：将1张[アンノウン・マザーグース]加入手卡。
	/// </summary>
    public class S_HatsuneMiku_12Rare:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);

            for (int i = 0; i < 5; i++)
            {
                Targets[0].BuffAdd("B_HatsuneMiku_P", this.BChar, false, 0, false, -1, false);
            }

            if (Targets[0].BuffFind("B_HatsuneMiku_P", false) && Targets[0].BuffReturn("B_HatsuneMiku_P", false).StackNum >= 12)
            {
                Skill tmpSkill = Skill.TempSkill("S_HatsuneMiku_12Rare_0", this.BChar, this.BChar.MyTeam);
                BattleSystem.instance.AllyTeam.Add(tmpSkill, true);
            }
        }
    }
}