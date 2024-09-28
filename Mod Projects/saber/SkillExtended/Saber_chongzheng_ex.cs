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
    public class Saber_chongzheng_ex:Skill_Extended
    {
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
        public override void Init()
        {
            base.Init();
            this.SkillParticleObject = new GDESkillExtendedData(GDEItemKeys.SkillExtended_Public_1_Ex).Particle_Path;
        }
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);
            bool flag = Ex_Saber_jiefang.Checkjianshi(1, this.BChar);
            if (flag)
            {
                Ex_Saber_jiefang.Usejianshi(1, this.BChar);
                BuffTag buffTag = new BuffTag
                {
                    User = this.BChar,
                    BuffData = new GDEBuffData("Saber_zhengbei_huzhao")
                };
                this.TargetBuff.Add(buffTag);
            }
            foreach (BattleChar battleChar in this.BChar.MyTeam.AliveChars)
            {
                battleChar.Overload = 0;
            }
        }
        public int checkCount = 0;
    }
   
}