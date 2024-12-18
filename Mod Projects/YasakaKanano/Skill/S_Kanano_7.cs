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
	/// 神秘「葛井之清水」
	/// <color=#FFC125>穗收3</color> - 回合结束时，若<color=#CD5555>饥馑5</color> - 将本回合释放过的1个技能拿回手中；否则抽取1个技能。
	/// <color=#CD5555>饥馑10</color> - 生成1个[西风灵]。
	/// </summary>
    public class S_Kanano_7: Skillbase_Kanano
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
                if (CheckDeck2(10))
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
            if (CheckDeck1(3, false))
            {
                this.BChar.BuffAdd("B_Kanano_7", this.BChar);
            }

            if (CheckDeck2(10))
            {
                Skill tmpSkill = Skill.TempSkill("S_Kanano_P", this.BChar, this.BChar.MyTeam);
                BattleSystem.instance.AllyTeam.Add(tmpSkill, true);
            }
        }
    }
}