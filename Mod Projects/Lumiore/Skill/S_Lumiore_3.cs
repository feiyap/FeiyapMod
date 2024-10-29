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
namespace Lumiore
{
	/// <summary>
	/// 碎石龙
	/// 激奏1：丢弃1个技能，抽取1个技能。觉醒：改为抽取2个。
	/// </summary>
    public class S_Lumiore_3:Skill_Extended
    {
        private bool useflag;
        private bool isSpecies;

        public override void Init()
        {
            base.Init();
            this.SkillParticleObject = new GDESkillExtendedData(GDEItemKeys.SkillExtended_Public_1_Ex).Particle_Path;
        }

        public override void FixedUpdate()
        {
            if (useflag)
            {
                return;
            }
            base.FixedUpdate();
            if (this.BChar.MyTeam.AP < 9)
            {
                this.isSpecies = true;
                if (this.BChar.MyTeam.MAXAP >= 7)
                {
                    base.SkillParticleOn();
                }
                else
                {
                    base.SkillParticleOff();
                }

                this.ChangedTarget = GDEItemKeys.s_targettype_Misc;
                this.APChange = -8;
            }
            else
            {
                this.isSpecies = false;

                this.ChangedTarget = GDEItemKeys.s_targettype_all_enemy;
                this.APChange = 0;
            }
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            useflag = true;
            if (!this.isSpecies)
            {
                return;
            }

            List<Skill> list = new List<Skill>();
            list.Add(BattleSystem.instance.AllyTeam.Skills.FindAll((Skill i) => i != this.MySkill));
            BattleSystem.DelayInputAfter(BattleSystem.I_OtherSkillSelect(list, new SkillButton.SkillClickDel(this.Del), ScriptLocalization.System_SkillSelect.WasteSkill, false, true, true, false, true));
        }

        public void Del(SkillButton Mybutton)
        {
            Mybutton.Myskill.Delete(false);
            BattleSystem.instance.AllyTeam.Draw();
            if (this.BChar.MyTeam.MAXAP >= 7)
            {
                BattleSystem.instance.AllyTeam.Draw();
            }
        }
    }
}