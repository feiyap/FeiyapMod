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
	/// 御柱「上升御柱」
	/// 生成1个[风灵]。
	/// <color=#CD5555>饥馑10</color> - 生成1个[西风灵]。
	/// </summary>
    public class S_Kanano_3: Skillbase_Kanano
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
            if (CheckDeck2(10))
            {
                Skill tmpSkill = Skill.TempSkill("S_Kanano_P", this.BChar, this.BChar.MyTeam);
                BattleSystem.instance.AllyTeam.Add(tmpSkill, true);
            }

            MySkill.MySkill.Effect_Self.Buffs.Clear();
            this.SelfBuff.Clear();

            BattleSystem.instance.GetBattleValue<BV_Kanano_P>().addYuzhuBuff("B_Kanano_3", this.BChar);
        }
    }
}