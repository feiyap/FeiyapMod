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
namespace VillageAlice
{
	/// <summary>
	/// 童话
	/// 释放后，进入[梦境]。
	/// </summary>
    public class SkillExtended_Fairytale:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);

            this.BChar.BuffAdd("B_FVAlice_P_1", this.BChar);
        }

        public override void FixedUpdate()
        {
            if (!this.flag && BattleSystem.instance != null && !this.BChar.BuffFind("B_FVAlice_P_1"))
            {
                this.flag = true;
                UnityEngine.Object.Instantiate(Resources.Load("StoryGlitch/GlitchSkillEffect"), this.MySkill.MyButton.transform);
            }
        }

        public bool flag;
    }
}