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
using System.Drawing;
namespace saber
{
    public class Saber_shengjian_ex:Skill_Extended
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
            bool flag3 = this.BChar.BuffFind("Saber_moli", false);
            if (flag3)
            {
                int num = this.BChar.BuffReturn("Saber_moli", false).StackNum;
                this.APChange = -num;
            }
        }
        public int checkCount = 0;
        // Token: 0x06000AC8 RID: 2760 RVA: 0x0007C855 File Offset: 0x0007AA55
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            int num = 0;
            List<Skill> list = new List<Skill>();
            list.AddRange(BattleSystem.instance.AllyTeam.Skills);
            foreach (Skill skill in list)
            {
                if (skill.IsDamage && skill != this.MySkill)
                {
                    num++;
                    skill.Delete();
                }
            }
            bool flag = Ex_Saber_jiefang.Checkjianshi(1, this.BChar);
            if (flag)
            {
                Ex_Saber_jiefang.Usejianshi(1, this.BChar);
                this.MySkill.Master.MyTeam.Draw(num / 2);
            }
            this.SkillBasePlus.Target_BaseDMG = 10 * num;
            bool flag3 = this.BChar.BuffFind("Saber_moli", false) && this.BChar.BuffReturn("Saber_moli", false).StackNum < 6;
            if (flag3)
            {
                int num2 = this.BChar.BuffReturn("Saber_moli", false).StackNum;
                BattleSystem.instance.AllyTeam.AP++;
                Ex_Saber_jiefang.Usemoli(num2, this.BChar);
            }
        }
        private void ObtainCopy()
        {
            if (this.MySkill.ExtendedFind(ModItemKeys.SkillExtended_Saber_shengjian_ex, true) == null)
            {
                Skill skill = Skill.TempSkill(ModItemKeys.Skill_Saber_shengjian, this.BChar, this.BChar.MyTeam);
                BattleSystem.instance.AllyTeam.Add(skill, true);
            }
        }

        // Token: 0x06001169 RID: 4457 RVA: 0x00091611 File Offset: 0x0008F811
        public override void SkillKill(SkillParticle SP)
        {
            base.SkillKill(SP);
            this.ObtainCopy();
        }
    }
}