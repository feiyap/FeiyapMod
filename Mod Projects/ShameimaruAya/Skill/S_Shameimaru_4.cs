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
namespace ShameimaruAya
{
	/// <summary>
	/// 风符「风神一扇」
	/// 握在手中时，使用3个技能后，释放这个技能时生成1张[风符「风神一扇」]。
	/// </summary>
    public class S_Shameimaru_4:Skill_Extended, IP_SkillUseHand_Team
    {
        public int count;

        public override void Init()
        {
            base.Init();
            this.SkillParticleObject = new GDESkillExtendedData(GDEItemKeys.SkillExtended_Public_1_Ex).Particle_Path;
            count = 0;
            OnePassive = true;
        }

        public int fixCount = 0;

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            if (fixCount >= 12)
            {
                fixCount = 0;
                if (CheckUsedSkills(3))
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
            if (CheckUsedSkills(3))
            {
                Skill tmpSkill = Skill.TempSkill("S_Shameimaru_4", this.BChar, this.BChar.MyTeam);
                tmpSkill.isExcept = true;
                BattleSystem.instance.AllyTeam.Add(tmpSkill, true);
            }
        }

        public void SKillUseHand_Team(Skill skill)
        {
            count++;
        }

        public bool CheckUsedSkills(int skillCount)
        {
            return count >= skillCount;
        }
    }
}