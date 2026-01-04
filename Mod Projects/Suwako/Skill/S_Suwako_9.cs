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
namespace Suwako
{
    /// <summary>
    /// 祟符「御社宫司大人」
    /// <color=green>连击4</color> - 必定暴击，生成 1 个“南风灵”。
    /// </summary>
    public class S_Suwako_9: SkillExtend_Suwako
    {
        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
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
                if (CheckUsedSkills(4))
                {
                    base.SkillParticleOn();
                    this.PlusSkillStat.cri = 100f;
                }
                else
                {
                    base.SkillParticleOff();
                    this.PlusSkillStat.cri = 0;
                }
            }
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);

            if (CheckUsedSkills(4))
            {
                Skill tmpSkill = Skill.TempSkill("S_Suwako_P", this.BChar, this.BChar.MyTeam);
                BattleSystem.instance.AllyTeam.Add(tmpSkill, true);
            }
        }
    }
}