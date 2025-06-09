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
namespace Feiyap
{
	/// <summary>
	/// 绯夜流·一式
	/// </summary>
    public class S_Feiyap_0:Skill_Extended
    {
        public bool isuse = false;

        public int PlusDmg
        {
            get
            {
                if (BattleSystem.instance == null || BattleSystem.instance.BattleLogs == null || BattleSystem.instance.TurnNum <= 0)
                {
                    return 0;
                }
                return (int)((float)(0 + this.BChar.GetStat.atk * 0.5f));
            }
        }

        public override void Init()
        {
            base.Init();
            this.SkillParticleObject = new GDESkillExtendedData(GDEItemKeys.SkillExtended_MissChain_Ex_P).Particle_Path;
            if (this.BChar.GetStat.Strength)
            {
                this.SkillBasePlus.Target_BaseDMG = this.PlusDmg;
            }
            else
            {
                this.SkillBasePlus.Target_BaseDMG = 0;
            }
            isuse = false;
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            if (isuse)
            {
                return;
            }
            if (this.BChar.GetStat.Strength)
            {
                base.SkillParticleOn();
                this.SkillBasePlus.Target_BaseDMG = this.PlusDmg;
            }
            else
            {
                base.SkillParticleOff();
                this.SkillBasePlus.Target_BaseDMG = 0;
            }
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);
            if (this.BChar.GetStat.Strength)
            {
                this.SkillBasePlus.Target_BaseDMG = this.PlusDmg;
            }
            else
            {
                this.SkillBasePlus.Target_BaseDMG = 0;
                this.BChar.BuffAdd("B_Feiyap_0", this.BChar);
            }
            isuse = true;
        }

        public override string DescExtended(string desc)
        {
            return base.DescExtended(desc).Replace("&a", (this.PlusDmg).ToString());
        }
    }
}