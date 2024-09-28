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
    public class Saber_EXCalibur_EX : Skill_Extended, IP_SkillCastingStart
    {
        public override void FixedUpdate()
        {
            bool flag = this.BChar.BuffFind("Saber_moli", false);
            if (flag)
            {
                int num = this.BChar.BuffReturn("Saber_moli", false).StackNum;
                bool flag2 = num >= 5;
                if (flag2)
                {
                    this.Flag = true;
                }

            }
            base.FixedUpdate();
            this.checkCount++;
            bool flag3 = this.checkCount >= 12;
            if (flag3)
            {
                this.checkCount = 0;
                bool flag4 = Ex_Saber_jiefang.Checkmoli(5, this.BChar);
                if (flag4)
                {
                    base.SkillParticleOn();
                }
                else
                {
                    base.SkillParticleOff();
                }
            }
        }
        public override void Init()
        {
            base.Init();
            this.PlusSkillStat.Penetration = 100f;
            base.Init();
            this.SkillParticleObject = new GDESkillExtendedData(GDEItemKeys.SkillExtended_Public_1_Ex).Particle_Path;
        }
        public void SkillCasting(CastingSkill ThisSkill)
        {
            bool flag = Ex_Saber_jiefang.Checkmoli(5, this.BChar);
            if (flag)
            {
                BattleSystem.instance.AllyTeam.AP++;
                Ex_Saber_jiefang.Usemoli(5, this.BChar);
            }
            bool flag2 = Ex_Saber_jiefang.Checkjianshi(1, this.BChar);
            if (flag2)
            {
                BattleSystem.instance.AllyTeam.AP++;
                Ex_Saber_jiefang.Usejianshi(1, this.BChar);
                this.MySkill.Master.MyTeam.Draw(2);
            }
            this.BChar.BuffAdd(ModItemKeys.Buff_Saber_xuli, this.BChar, false, 0, false, -1, false);
        }
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            this.BChar.BuffRemove(ModItemKeys.Buff_Saber_xuli, this.BChar);
            this.BChar.BuffAdd(ModItemKeys.Buff_Saber_wudi, this.BChar, false, 0, false, -1, false);
            base.SkillUseSingle(SkillD, Targets);
            bool flag = Ex_Saber_jiefang.Checkxunli(1, this.BChar);
            if (flag)
            {
                BattleSystem.instance.AllyTeam.AP++;
                this.BChar.MyTeam.partybarrier.BarrierHP += (int)(this.BChar.GetStat.maxhp * 0.3f);
            }
            bool flag3 = Ex_Saber_jiefang.Checkjiejie(1, this.BChar);
            if (flag3)
            {
                BattleSystem.instance.AllyTeam.AP++;
                BuffTag buffTag = new BuffTag();
                buffTag.User = this.BChar;
                buffTag.BuffData = new GDEBuffData("Saber_fengshi");
                this.TargetBuff.Add(buffTag);
                this.TargetBuff.Add(buffTag);
                this.TargetBuff.Add(buffTag);
                this.TargetBuff.Add(buffTag);
            }
            bool flag4 = Ex_Saber_jiefang.Checkjiejie1(1, this.BChar);
            if (flag4)
            {
                BattleSystem.instance.AllyTeam.AP++;
                BuffTag buffTag = new BuffTag();
                buffTag.User = this.BChar;
                buffTag.BuffData = new GDEBuffData("Saber_fengshi");
                this.TargetBuff.Add(buffTag);
                this.TargetBuff.Add(buffTag);
                this.TargetBuff.Add(buffTag);
                this.TargetBuff.Add(buffTag);
            }
        }
        public override bool Terms()
        {
            return this.Flag;
        }
        public void TurnEnd()
        {
            this.Flag = false;
        }
        public int checkCount = 0;
        public bool Flag;
    }
}
