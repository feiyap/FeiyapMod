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
namespace saber
{
    public class Saber_fengya_ex : Skill_Extended
    {
        public override void FixedUpdate()
        {
            base.FixedUpdate();
            this.checkCount++;
            bool flag = this.checkCount >= 12;
            if (flag)
            {
                this.checkCount = 0;
                bool flag2 = Ex_Saber_jiefang.Checkmoli(2, this.BChar);
                if (flag2)
                {
                    base.SkillParticleOn();
                }
                else
                {
                    base.SkillParticleOff();
                }
                bool flag3 = Ex_Saber_jiefang.Checkjiejie(1, this.BChar);
                if (flag3)
                {
                    base.SkillParticleOn();
                }
            }

        }
        public override void Init()
        {
            base.Init();
            this.SkillParticleObject = new GDESkillExtendedData(GDEItemKeys.SkillExtended_Public_1_Ex).Particle_Path;
        }
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);
            bool flag = Ex_Saber_jiefang.Checkmoli(2, this.BChar);
            if (flag)
            {
                BattleSystem.instance.AllyTeam.AP++;
                Ex_Saber_jiefang.Usemoli(2, this.BChar);
                this.BChar.MyTeam.partybarrier.BarrierHP += (int)(this.BChar.GetStat.maxhp * 0.2f);
            }
            bool flag2 = Ex_Saber_jiefang.Checkjiejie(1, this.BChar);
            if (flag2)
            {
                BattleSystem.instance.AllyTeam.AP++;
                BuffTag buffTag = new BuffTag();
                buffTag.User = this.BChar;
                buffTag.BuffData = new GDEBuffData("Saber_fengshi");
                this.TargetBuff.Add(buffTag);
            }
            bool flag3 = Ex_Saber_jiefang.Checkjiejie1(1, this.BChar);
            if (flag3)
            {
                BattleSystem.instance.AllyTeam.AP++;
                BuffTag buffTag = new BuffTag();
                buffTag.User = this.BChar;
                buffTag.BuffData = new GDEBuffData("Saber_fengshi");
                this.TargetBuff.Add(buffTag);
            }
        }
        public int checkCount = 0;
    }
}