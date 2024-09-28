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
	/// <summary>
	/// 伤符「铭刻于红魂」
	/// 月魔术：指定全部敌人。
	/// </summary>
    public class S_Sakuya_2:Skill_Extended
    {
        public bool flag;

        public override void Init()
        {
            base.Init();
            this.SkillParticleObject = new GDESkillExtendedData(GDEItemKeys.SkillExtended_Public_1_Ex).Particle_Path;
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            if (BattleSystem.instance != null && BattleSystem.instance.AllyTeam.Skills.Count != 0)
            {
                flag = false;
                base.SkillParticleOff();
                this.MySkill.MySkill.Name = "伤符「铭刻于红魂」";
                this.MySkill.MySkill.Target = new GDEs_targettypeData(GDEItemKeys.s_targettype_enemy);
                if (this.MySkill == BattleSystem.instance.AllyTeam.Skills[BattleSystem.instance.AllyTeam.Skills.Count - 1]
                    || this.MySkill == BattleSystem.instance.AllyTeam.Skills[0]
                    || this.MySkill.ExtendedFind_DataName("SE_Sakuya_7") != null
                    || this.BChar.BuffFind("B_Sakuya_12Rare"))
                {
                    flag = true;
                    base.SkillParticleOn();
                    this.MySkill.MySkill.Name = "伤魂「灵魂雕塑」";
                    this.MySkill.MySkill.Target = new GDEs_targettypeData(GDEItemKeys.s_targettype_all_enemy);
                }
            }
        }
    }
}