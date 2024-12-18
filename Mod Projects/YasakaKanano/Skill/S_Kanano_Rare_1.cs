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
	/// 「风神之神德」
	/// 生成1个[风灵]和1个[西风灵]。
	/// </summary>
    public class S_Kanano_Rare_1:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);

            BattleSystem.DelayInput(this.Effect());
        }
        
        public IEnumerator Effect()
        {
            this.BChar.MyTeam.AP = this.BChar.MyTeam.MAXAP;

            yield return null;
            yield break;
        }
    }
}