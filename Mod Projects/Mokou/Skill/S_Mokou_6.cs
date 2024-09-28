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
namespace Mokou
{
	/// <summary>
	/// 不死「徐福时空」
	/// 过热：4——将一张使用后放逐的不死「徐福时空」置入手中。
	/// 使用后，赤魂层数减少1层（可以再次复活1次）。
	/// </summary>
    public class S_Mokou_6:Skill_Extended
    {
        public override void Init()
        {
            base.Init();
            this.SkillParticleObject = new GDESkillExtendedData(GDEItemKeys.SkillExtended_MissChain_Ex_P).Particle_Path;
        }
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);
            if (this.BChar.BuffFind("B_Mokou_0",false))
            {
                this.BChar.BuffReturn("B_Mokou_0", false).SelfStackDestroy();
            }
        }
    }
}