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
	/// 突符「天狗巨暴流」
	/// 手中每有1个0费的技能，伤害增加&a(10%)点。
	/// <b><color=green>连击4</color></b> - 释放前，生成2个[北风灵]。
	/// </summary>
    public class S_Shameimaru_5: SE_Shameimaru_Combo
    {
        public override void Init()
        {
            base.Init();
            this.SkillParticleObject = new GDESkillExtendedData(GDEItemKeys.SkillExtended_Public_1_Ex).Particle_Path;
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            if (CheckUsedSkills(4))
            {
                base.SkillParticleOn();
            }
            else
            {
                base.SkillParticleOff();
            }
            int num = 0;
            for (int i = 0; i < this.BChar.MyTeam.Skills.Count; i++)
            {
                if (this.BChar.MyTeam.Skills[i] != this.MySkill)
                {
                    num++;
                }
            }
            this.SkillBasePlus.Target_BaseDMG = (int)((double)num * 0.1 * (double)this.BChar.GetStat.atk);
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            if (CheckUsedSkills(4))
            {
                Skill tmpSkill = Skill.TempSkill("S_Shameimaru_P", this.BChar, this.BChar.MyTeam);
                BattleSystem.instance.AllyTeam.Add(tmpSkill, true);
                Skill tmpSkill2 = Skill.TempSkill("S_Shameimaru_P", this.BChar, this.BChar.MyTeam);
                BattleSystem.instance.AllyTeam.Add(tmpSkill2, true);
            }

            int num = 0;
            for (int i = 0; i < this.BChar.MyTeam.Skills.Count; i++)
            {
                if (this.BChar.MyTeam.Skills[i] != this.MySkill)
                {
                    num++;
                }
            }
            this.SkillBasePlus.Target_BaseDMG = (int)((double)num * 0.1 * (double)this.BChar.GetStat.atk);
        }

        public override string DescExtended(string desc)
        {
            return base.DescExtended(desc).Replace("&a", ((int)(this.BChar.GetStat.atk * 0.1f)).ToString());
        }
    }
}