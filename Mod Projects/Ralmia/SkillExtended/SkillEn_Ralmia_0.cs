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
namespace Ralmia
{
	/// <summary>
	/// 创造物
	/// 这个技能被当做创造物。
	/// </summary>
    public class SkillEn_Ralmia_0:Skill_Extended
    {
        public override string DescExtended(string desc)
        {
            return ModManager.getModInfo("Ralmia").localizationInfo.SystemLocalizationUpdate("ArtifactInfo") + "\n\n" + base.DescExtended(desc);
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            if (this.BChar.BuffFind("B_Ralmia_0", false))
            {
                BattleSystem.instance.AllyTeam.Draw();
                BattleTeam allyTeam = BattleSystem.instance.AllyTeam;
                int ap = allyTeam.AP;
                allyTeam.AP = ap + 1;
            }

            if (this.BChar.BuffFind("B_Ralmia_1", false))
            {
                BattleTeam allyTeam = BattleSystem.instance.AllyTeam;
                int ap = allyTeam.AP;
                allyTeam.AP = ap + 1;
            }

            if (BattleSystem.instance.GetBattleValue<BV_Artifact>() == null)
            {
                BattleSystem.instance.BattleValues.Add(new BV_Artifact());
            }
            BattleSystem.instance.GetBattleValue<BV_Artifact>().checkNewType(SkillD);
        }

        public int fixCount = 0;

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            fixCount++;
            if (fixCount >= 12)
            {
                fixCount = 0;
                if (this.BChar.BuffFind("B_Ralmia_1", false))
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
    }
}