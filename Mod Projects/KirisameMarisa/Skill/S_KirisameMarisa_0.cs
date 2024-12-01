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
namespace KirisameMarisa
{
	/// <summary>
	/// 星符「Meteonic Shower」
	/// 该技能不会增加过载。本回合内可重复释放。
	/// </summary>
    public class S_KirisameMarisa_0: SkillBase_KirisameMarisa
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            this.BChar.Overload -= 1;

            Skill tmpSkill = Skill.TempSkill("S_KirisameMarisa_0", this.BChar, this.BChar.MyTeam);
            tmpSkill.isExcept = true;
            tmpSkill.AutoDelete = 1;
            BattleSystem.instance.AllyTeam.Add(tmpSkill, true);
        }
    }
}