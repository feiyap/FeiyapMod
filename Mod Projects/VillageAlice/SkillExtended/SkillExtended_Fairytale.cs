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

            this.BChar.BuffReturn("B_FVAlice_P")?.SelfDestroy();
            this.BChar.BuffAdd("B_FVAlice_P_1", this.BChar);

            foreach (IP_ChangeReality ip in BattleSystem.instance.IReturn<IP_ChangeReality>())
            {
                if (ip != null)
                {
                    ip.ChangeReality(true);
                }
            }
        }

        public override void FixedUpdate()
        {
            if (this.BChar.BuffFind("B_FVAlice_P_1"))
            {
                this.flag = false;
                UnityEngine.Object.Destroy(obj, 1f);
                return;
            }
            
            if (!this.flag && BattleSystem.instance != null && !this.BChar.BuffFind("B_FVAlice_P_1"))
            {
                this.flag = true;
                obj = UnityEngine.Object.Instantiate(Resources.Load("StoryGlitch/GlitchSkillEffect"), this.MySkill.MyButton.transform);
                return;
            }
        }

        public override void SelfDestroy()
        {
            base.SelfDestroy();
            UnityEngine.Object.Destroy(obj, 1f);
        }

        public bool flag;
        public UnityEngine.Object obj;
    }
}