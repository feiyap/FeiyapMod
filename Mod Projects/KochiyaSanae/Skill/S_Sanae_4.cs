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
	/// 奇迹「客星璀璨之夜」
	/// <b><color=green>连击4</color></b> - 抽取1个技能。如果抽到的技能原始费用为1点，降低至0费。
	/// </summary>
    public class S_Sanae_4: SE_Sanae_Combo
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
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            if (CheckUsedSkills(4))
            {
                BattleSystem.DelayInputAfter(this.Draw(Targets[0]));
            }
        }

        public void DrawInput(Skill skill)
        {
            if (skill._AP == 1)
            {
                skill.APChange = -9;
            }
        }

        public IEnumerator Draw(BattleChar battlechar)
        {
            yield return BattleSystem.instance.AllyTeam._Draw(new BattleTeam.DrawInput(this.DrawInput));

            yield return null;
            yield break;
        }
    }
}