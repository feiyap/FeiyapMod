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
	/// 龙之嗔怒
	/// 选择-从[罗文的咆哮][拜迪的爪牙]中选1张打出。
	/// 觉醒：从选择改为同时打出。
	/// 罗文的咆哮：使自己最大法力值+1。
	/// 拜迪的爪牙：对随机一个敌人造成&a伤害。
	/// </summary>
    public class S_Lumiore_7:Skill_Extended
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
            if (this.BChar.MyTeam.MAXAP >= 7)
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
            if (!isSpecies)
            {
                List<Skill> list = new List<Skill>();
                list.Add(Skill.TempSkill("S_Lumiore_7_0", this.BChar, this.BChar.MyTeam));
                list.Add(Skill.TempSkill("S_Lumiore_7_1", this.BChar, this.BChar.MyTeam));
                BattleSystem.DelayInputAfter(BattleSystem.I_OtherSkillSelect(list, new SkillButton.SkillClickDel(this.Del), ScriptLocalization.System_SkillSelect.CreateSkill, false, true, true, false, true));
            }
            else
            {
                Skill skill = Skill.TempSkill("S_Lumiore_7_0", this.BChar, this.BChar.MyTeam).CloneSkill(false, null, null, false);
                BattleSystem.DelayInput(BattleSystem.instance.ForceAction(skill, this.BChar as BattleChar, false, false, true, null));
                Skill skill2 = Skill.TempSkill("S_Lumiore_7_1", this.BChar, this.BChar.MyTeam).CloneSkill(false, null, null, false);
                BattleSystem.DelayInput(BattleSystem.instance.ForceAction(skill2, BattleSystem.instance.EnemyTeam.AliveChars.Random(this.BChar.GetRandomClass().Main), false, false, true, null));
            }
        }

        public void Del(SkillButton Mybutton)
        {
            BattleSystem.DelayInput(BattleSystem.instance.ForceAction(Mybutton.Myskill, Mybutton.Myskill.DelObj as BattleChar, false, false, true, null));
        }

        public override string DescExtended(string desc)
        {
            return base.DescExtended(desc).Replace("&a", ((int)(this.BChar.GetStat.atk * 1.5f)).ToString());
        }
    }
}