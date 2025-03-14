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
	/// 神祭「扩展御柱」
	/// <color=#FFC125>穗收2</color> - 这个技能必定暴击。
	/// </summary>
    public class S_Kanano_0: Skillbase_Kanano
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
                if (CheckDeck1(2, true))
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
            if (CheckDeck1(2, false))
            {
                this.PlusSkillStat.cri = 100f;
            }

            MySkill.MySkill.Effect_Self.Buffs.Clear();
            this.SelfBuff.Clear();

            BattleSystem.instance.GetBattleValue<BV_Kanano_P>().addYuzhuBuff("B_Kanano_0", this.BChar);
        }
    }
}