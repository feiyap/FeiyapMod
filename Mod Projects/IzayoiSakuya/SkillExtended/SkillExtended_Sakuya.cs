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
namespace IzayoiSakuya
{
    public class SkillExtended_Sakuya:Skill_Extended
    {
        public override void Init()
        {
            base.Init();
            this.SkillParticleObject = new GDESkillExtendedData(GDEItemKeys.SkillExtended_Public_1_Ex).Particle_Path;
        }

        public int Fixed_count = 0;

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            Fixed_count++;

            if (Fixed_count >= 12)
            {
                Fixed_count = 0;

                if (BattleSystem.instance != null && BattleSystem.instance.AllyTeam.Skills.Count != 0)
                {
                    base.SkillParticleOff();

                    if (this.MySkill == BattleSystem.instance.AllyTeam.Skills[BattleSystem.instance.AllyTeam.Skills.Count - 1] // ÷≈∆µ◊
                        || this.MySkill == BattleSystem.instance.AllyTeam.Skills[0] // ÷≈∆∂•
                        || this.MySkill.ExtendedFind_DataName("SE_Sakuya_7") != null) //Œ·»–ªÿπÈ
                    {
                        base.SkillParticleOn();
                        this.MySkill.MySkill.Name = ModManager.getModInfo("IzayoiSakuya").localizationInfo.SystemLocalizationUpdate(this.MySkill.MySkill.KeyID + "L");
                    }
                    else
                    {
                        this.MySkill.MySkill.Name = ModManager.getModInfo("IzayoiSakuya").localizationInfo.SystemLocalizationUpdate(this.MySkill.MySkill.KeyID + "N");
                    }
                }
            }
        }

        public bool CheckLunaMagic()
        {
            if (this.MySkill == BattleSystem.instance.AllyTeam.Skills[BattleSystem.instance.AllyTeam.Skills.Count - 1] // ÷≈∆µ◊
                        || this.MySkill == BattleSystem.instance.AllyTeam.Skills[0] // ÷≈∆∂•
                        || this.MySkill.ExtendedFind_DataName("SE_Sakuya_7") != null) //Œ·»–ªÿπÈ
            {
                return true;
            }

            return false;
        }
    }
}