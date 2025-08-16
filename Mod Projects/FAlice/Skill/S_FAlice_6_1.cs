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
	/// 选择 1 个「人形」技能，立即强化触发 1 次。
	/// </summary>
    public class S_FAlice_6_1 : Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);
            SkillExtended_FAlice.ChooseDollAndEffect((doll) =>
            {
                doll.TriggerEffect(true);
            }, ScriptLocalization.System_SkillSelect.EffectSelect);
        }
    }
}