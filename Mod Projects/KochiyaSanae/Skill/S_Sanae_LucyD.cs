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
namespace KochiyaSanae
{
	/// <summary>
	/// 祈愿「守护商业繁荣」
	/// 抽取1个技能。生成1个[风灵]。
	/// <b><color=green>连击2</color></b> - 额外抽取1个技能。生成1个[东风灵]。
	/// </summary>
    public class S_Sanae_LucyD: SE_Sanae_Combo
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
            if (fixCount >= 12)
            {
                fixCount = 0;
                if (CheckUsedSkills(2))
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
            BattleSystem.instance.AllyTeam.Draw();
            if (CheckUsedSkills(2))
            {
                BattleSystem.instance.AllyTeam.Draw();
            }

            using (List<BattleChar>.Enumerator enumerator = BattleSystem.instance.AllyTeam.AliveChars.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    if (enumerator.Current.Info.KeyData == "KochiyaSanae")
                    {
                        Skill tmpSkill = Skill.TempSkill("S_FSL_Common", enumerator.Current, enumerator.Current.MyTeam);
                        BattleSystem.instance.AllyTeam.Add(tmpSkill, true);
                        if (CheckUsedSkills(2))
                        {
                            Skill tmpSkill2 = Skill.TempSkill("S_Sanae_P", enumerator.Current, enumerator.Current.MyTeam);
                            BattleSystem.instance.AllyTeam.Add(tmpSkill2, true);
                        }
                        break;
                    }
                }
            }
        }
    }
}