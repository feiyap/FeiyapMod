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
    public class Saber_lingdao_ex : Skill_Extended
    {
        public override void FixedUpdate()
        {
            base.FixedUpdate();
            this.checkCount++;
            bool flag = this.checkCount >= 12;
            if (flag)
            {
                this.checkCount = 0;
                bool flag2 = Ex_Saber_jiefang.Checkmoli(3, this.BChar);
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
            bool flag = Ex_Saber_jiefang.Checkmoli(3, this.BChar);
            if (flag)
            {
                BattleSystem.instance.AllyTeam.AP++;
                Ex_Saber_jiefang.Usemoli(3, this.BChar);
                this.MySkill.Master.MyTeam.Draw(2);
            }
            base.SkillUseSingle(SkillD, Targets);
            foreach (BattleChar battleChar in BattleSystem.instance.AllyList)
            {
                bool flag2 = !battleChar.BuffFind("SaberBuff", false);
                if (flag2)
                {
                    battleChar.BuffAdd("Saber_lingdao_B", this.BChar, false, 0, false, -1, false);
                }
            }
            bool flag3 = Ex_Saber_jiefang.Checkxunli(1, this.BChar);
            if (flag3)
            {
                this.BChar.MyTeam.partybarrier.BarrierHP += (int)(20);
            }
            else
            {
                foreach (BattleChar battleChar in BattleSystem.instance.AllyList)
                {
                    bool flag4 = battleChar.BuffFind("SaberBuff", true);
                    if (flag4)
                    {
                        battleChar.BuffAdd("Saber_yingxiong_B", this.BChar, false, 0, false, -1, false);
                    }
                }
            }
        }
        public override void Init()
        {
            base.Init();
            this.SkillParticleObject = new GDESkillExtendedData(GDEItemKeys.SkillExtended_Public_1_Ex).Particle_Path;
        }
        public int checkCount = 0;
    }
} 
   

    

