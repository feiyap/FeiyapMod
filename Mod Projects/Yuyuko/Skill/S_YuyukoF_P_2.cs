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
namespace Yuyuko
{
	/// <summary>
	/// <color=#4876FF>亡乡「亡我乡 -自尽-」</color>
	/// 立即获得100返魂值，并进入永眠状态。
	/// </summary>
    public class S_YuyukoF_P_2:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            Targets[0].Heal(this.BChar, (int)(Targets[0].GetStat.maxhp * 0.5), true, false);
        }

        public override void AttackEffectSingle(BattleChar hit, SkillParticle SP, int DMG, int Heal)
        {
            BattleSystem.instance.GetBattleValue<BV_YuyukoF_P>().setFanhun(100);
        }
    }
}