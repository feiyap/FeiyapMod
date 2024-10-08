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
	/// <color=#FFA500>开眼者·乌诺</color>
	/// <color=#FFC125>进化5</color> - 施加[开眼者]：永久；受到的伤害降低2点。
	/// </summary>
    public class S_HolySaber_9__Ex: SkillExtended_HolySaber
    {
        public int Fixed_count = 0;

        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
            this.SkillParticleObject = new GDESkillExtendedData(GDEItemKeys.SkillExtended_Public_1_Ex).Particle_Path;
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            Fixed_count++;

            if (Fixed_count >= 12)
            {
                Fixed_count = 0;

                if (CheckUsedExSkills(5))
                {
                    base.SkillParticleOn();
                }
                else
                {
                    base.SkillParticleOff();
                }
            }
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);

            MySkill.MySkill.Effect_Target.Buffs.Clear();
            this.TargetBuff.Clear();

            foreach (BattleChar bc in Targets)
            {
                bc.BuffAdd("B_HolySaber_9_0", this.BChar);
                if (CheckUsedExSkills(5))
                {
                    bc.BuffAdd("B_HolySaber_9", this.BChar);
                }
            }
        }
    }
}