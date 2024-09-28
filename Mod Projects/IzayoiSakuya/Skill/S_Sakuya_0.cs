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
    /// 女仆秘技「杀人玩偶」
    /// 打出时若在手牌顶或手牌底，将1张[时符「调换魔法」]加入手中。
    /// </summary>
    public class S_Sakuya_0:Skill_Extended
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
                this.MySkill.MySkill.Name = "女仆秘技「操弄玩偶」";
                if (this.MySkill == BattleSystem.instance.AllyTeam.Skills[BattleSystem.instance.AllyTeam.Skills.Count - 1]
                    || this.MySkill == BattleSystem.instance.AllyTeam.Skills[0]
                    || this.MySkill.ExtendedFind_DataName("SE_Sakuya_7") != null
                    || this.BChar.BuffFind("B_Sakuya_12Rare"))
                {
                    flag = true;
                    base.SkillParticleOn();
                    this.MySkill.MySkill.Name = "女仆秘技「杀人玩偶」";
                }
            }
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            if (this.flag)
            {
                Skill tmpSkill = Skill.TempSkill("S_Sakuya_0_0", this.BChar, this.BChar.MyTeam);
                BattleSystem.instance.AllyTeam.Add(tmpSkill, true);
            }
        }
    }
}