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
namespace Jhin
{
	/// <summary>
	/// 完美谢幕
	/// 生成“完美谢幕 - 入场曲”。
	/// </summary>
    public class S_Jhin_Rare_1:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            Skill tmpSkill = Skill.TempSkill("S_Jhin_Rare_1_1", this.BChar, this.BChar.MyTeam);
            tmpSkill.isExcept = true;
            BattleSystem.instance.AllyTeam.Add(tmpSkill, true);

            if (BattleSystem.instance.GetBattleValue<BV_Jhin_P>() != null)
            {
                BattleSystem.instance.GetBattleValue<BV_Jhin_P>().shotNum = 1;
            }

            if (SkillD.Master.Info.KeyData == "Jhin")
            {
                MasterAudio.PlaySound("SE_Jhin_Rare_1", 1f, null, 0f, null, null, false, false);
            }
        }
    }
}