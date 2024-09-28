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
using NLog.Targets;
namespace saber
{
    public class Saber_duangang_ex : Skill_Extended
    {
        public override void Init()
        {
            base.Init();
            this.PlusSkillStat.Penetration = 50f;
            base.Init();
            this.SkillParticleObject = new GDESkillExtendedData(GDEItemKeys.SkillExtended_Public_1_Ex).Particle_Path;
        }
        public override void SkillKill(SkillParticle SP)
        {
            bool flag = Ex_Saber_jiefang.Checkjianshi(1, this.BChar);
            if (flag)
            {
                Ex_Saber_jiefang.Usejianshi(1, this.BChar);
                BattleSystem.instance.AllyTeam.AP += 1;
                BattleSystem.DelayInput(BattleSystem.instance.SkillRandomUseIenum(this.BChar, this.MySkill, false, true, false));
            }
            
        }
        public override void FixedUpdate()
        {
            base.FixedUpdate();
            this.checkCount++;
            bool flag = this.checkCount >= 12;
            if (flag)
            {
                this.checkCount = 0;
                bool flag2 = Ex_Saber_jiefang.Checkjianshi(1, this.BChar);
                if (flag2)
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
            base.SkillUseSingle(SkillD, Targets);
            bool flag = Ex_Saber_jiefang.Checkmoli0(1, this.BChar);
            if (flag)
            {
                BattleSystem.instance.AllyTeam.AP++;
                BuffTag buffTag = new BuffTag();
                buffTag.User = this.BChar;
                buffTag.BuffData = new GDEBuffData("Saber_moli");
                this.SelfBuff.Add(buffTag);
            }
        }
        public int checkCount = 0;
    }
}