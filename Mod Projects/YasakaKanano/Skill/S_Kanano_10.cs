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
	/// 天龙「雨之源泉」
	/// <color=#CD5555>饥馑5</color> - 额外施加1层。
	/// </summary>
    public class S_Kanano_10: Skillbase_Kanano
    {
        public override void Init()
        {
            base.Init();
            this.SkillParticleObject = new GDESkillExtendedData(GDEItemKeys.SkillExtended_Public_1_Ex).Particle_Path;
        }

        public int fixCount = 0;

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            fixCount++;
            if (fixCount >= 12)
            {
                fixCount = 0;
                if (CheckDeck2(5))
                {
                    base.SkillParticleOn();
                    this.NotCount = true;
                }
                else
                {
                    base.SkillParticleOff();
                    this.NotCount = false;
                }
            }
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            if (CheckDeck2(5))
            {
                foreach (BattleChar bc in Targets)
                {
                    bc.BuffAdd("B_Kanano_10", this.BChar);
                }
            }
        }
    }
}