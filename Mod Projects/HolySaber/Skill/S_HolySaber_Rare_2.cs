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
namespace HolySaber
{
	/// <summary>
	/// 神谕的启程·贞德
	/// </summary>
    public class S_HolySaber_Rare_2: SkillExtended_HolySaber, IP_SkillUseHand_Team
    {
        public int count;

        public override void Init()
        {
            base.Init();
            this.SkillParticleObject = new GDESkillExtendedData(GDEItemKeys.SkillExtended_Public_1_Ex).Particle_Path;
            count = 0;
            OnePassive = true;
        }

        public void SKillUseHand_Team(Skill skill)
        {
            count++;
            if (count == 2)
            {
                SkillChange(this.MySkill, false);
            }
        }
    }
}