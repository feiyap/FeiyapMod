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
    public class Saber_ruodian_ex : Skill_Extended
    {
        public override void Init()
        {
            base.Init();
            this.SkillBasePlus.Target_BaseDMG = 0;
            this.SkillParticleObject = new GDESkillExtendedData(GDEItemKeys.SkillExtended_Public_1_Ex).Particle_Path;
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

        // Token: 0x06001176 RID: 4470 RVA: 0x00091870 File Offset: 0x0008FA70
        public override void Special_PointerEnter(BattleChar Char)
        {
            base.Special_PointerEnter(Char);
            this.SkillBasePlusPreview.Target_BaseDMG = 0;
            int num = 0;
            foreach (Buff buff2 in Char.Buffs)
            {
                int num3 = buff2.LifeTime;
                if (buff2.TimeUseless || buff2.LifeTime >= 4)
                {
                    num3 = buff2.LifeTime;
                }
                num += buff2.DotDMGView() * num3;
            }
            this.SkillBasePlusPreview.Target_BaseDMG = 2 * num;
        }

        // Token: 0x06001177 RID: 4471 RVA: 0x00091970 File Offset: 0x0008FB70
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);
            int num = 0;
            foreach (Buff buff2 in Targets[0].Buffs)
            {
                int num3 = buff2.LifeTime;
                if (buff2.TimeUseless)
                {
                    num3 = buff2.LifeTime;
                }
                num += buff2.DotDMGView() * num3;
            }
            base.SkillUseSingle(SkillD, Targets);
            if (Targets[0].HP <= Targets[0].GetStat.maxhp / 2)
            {
                this.PlusSkillStat.Penetration = 50;
            }
            bool flag = Ex_Saber_jiefang.Checkjianshi(1, this.BChar);
            if (flag)
            {
                Ex_Saber_jiefang.Usejianshi(1, this.BChar);
                this.PlusSkillStat.cri = 100;
            }
            this.SkillBasePlus.Target_BaseDMG = 2 * num;
        }
        public int checkCount = 0;
    }
}