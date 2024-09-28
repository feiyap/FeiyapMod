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
	/// 银色清纯·雅尔贞特
	/// 打出时舍弃自己2个技能，使自己最大法力值+1。
	/// 若「这张战斗中，丢弃手牌的次数」大于2次（不包括这个技能），则会抽取3个技能。
	/// </summary>
    public class S_Lumiore_5:Skill_Extended
    {
        private bool useflag;
        private bool isSpecies;

        public override void Init()
        {
            base.Init();
            count = 0;
            this.SkillParticleObject = new GDESkillExtendedData(GDEItemKeys.SkillExtended_Public_1_Ex).Particle_Path;
        }

        public override void FixedUpdate()
        {
            if (useflag)
            {
                return;
            }
            base.FixedUpdate();
            if (this.BChar.BuffFind("B_Lumiore_P", false) && this.BChar.BuffReturn("B_Lumiore_P", false).StackNum >= 2)
            {
                this.isSpecies = true;
                base.SkillParticleOn();
            }
            else
            {
                this.isSpecies = false;
                base.SkillParticleOff();
            }
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            useflag = true;
            list = new List<Skill>();
            list.AddRange(BattleSystem.instance.AllyTeam.Skills.FindAll((Skill y) => y != this.MySkill));
            for (int i = 0; i < 2; i++)
            {
                BattleSystem.DelayInputAfter(BattleSystem.I_OtherSkillSelect(list, new SkillButton.SkillClickDel(this.Del), ScriptLocalization.System_SkillSelect.WasteSkill, false, true, true, false, true));
            }
            BattleSystem.instance.AllyTeam.LucyChar.BuffAdd("B_Lumiore_5", BattleSystem.instance.AllyTeam.LucyChar, true, 0, false, -1, false);
        }

        public void Del(SkillButton Mybutton)
        {
            Mybutton.Myskill.Delete(false);
            list.Remove(Mybutton.Myskill);
            count++;
            if (count == 2)
            {
                count = 0;
                if (!isSpecies)
                {
                    return;
                }

                BattleSystem.instance.AllyTeam.Draw(3);
            }
        }

        public int count;
        private List<Skill> list;
    }
}