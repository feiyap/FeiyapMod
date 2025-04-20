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
namespace Feiyap
{
	/// <summary>
	/// 里绯夜流·逆鳞斩
	/// </summary>
    public class S_Feiyap_1:Skill_Extended
    {
        public override void Init()
        {
            base.Init();
            this.SkillParticleObject = new GDESkillExtendedData(GDEItemKeys.SkillExtended_MissChain_Ex_P).Particle_Path;
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            if (this.BChar.GetStat.Strength)
            {
                base.SkillParticleOn();
            }
            else
            {
                base.SkillParticleOff();
            }
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);
            if (this.BChar.GetStat.Strength)
            {
                foreach (BattleChar battleChar in Targets)
                {
                    int num = 0;
                    foreach (Buff buff in battleChar.Buffs)
                    {
                        num += buff.DotDMGView();
                    }
                    if (num > 0)
                    {
                        battleChar.Damage(this.BChar, num, false, true, false, 0, false, false, false);
                    }
                }
            }
        }
    }
}