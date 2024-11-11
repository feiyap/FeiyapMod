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
namespace RemiliaScarlet
{
	/// <summary>
	/// 狱符「千根针的针山」
	/// 这个技能造成伤害的250%将会超额治疗自己。
	/// </summary>
    public class S_RemiliaScarlet_7:Skill_Extended
    {
        public override void Init()
        {
            base.Init();
        }

        public override void AttackEffectSingle(BattleChar hit, SkillParticle SP, int DMG, int Heal)
        {
            this.BChar.Heal(this.BChar, (float)((int)((float)DMG * 2.5f)), this.BChar.GetCri(), true, null);
        }
    }
}