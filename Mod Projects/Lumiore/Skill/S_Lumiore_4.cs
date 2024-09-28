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
	/// 魔石巨蟹
	/// 将1张附带放逐的[城塞巨蟹]（0费，造成3倍攻击力伤害。）加入手中。
	/// 激奏2：迅速。丢弃1张手牌。抽取2个技能。
	/// </summary>
    public class S_Lumiore_4:Skill_Extended
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
            if (this.BChar.MyTeam.AP < 10)
            {
                this.isSpecies = true;

                this.ChangedTarget = GDEItemKeys.s_targettype_Misc;
                this.APChange = -8;
            }
            else
            {
                this.isSpecies = false;

                this.ChangedTarget = GDEItemKeys.s_targettype_enemy;
                this.APChange = 0;
            }
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            useflag = true;
            if (!this.isSpecies)
            {
                Skill tmpSkill = Skill.TempSkill("S_Lumiore_4_1", this.BChar, this.BChar.MyTeam);
                BattleSystem.instance.AllyTeam.Add(tmpSkill, true);
                return;
            }

            List<Skill> list = new List<Skill>();
            list.AddRange(BattleSystem.instance.AllyTeam.Skills.FindAll((Skill i) => i != this.MySkill));
            BattleSystem.DelayInputAfter(BattleSystem.I_OtherSkillSelect(list, new SkillButton.SkillClickDel(this.Del), ScriptLocalization.System_SkillSelect.WasteSkill, false, true, true, false, true));
        }

        public void Del(SkillButton Mybutton)
        {
            Mybutton.Myskill.Delete(false);
            BattleSystem.instance.AllyTeam.Draw(2);
        }

        public override string DescExtended(string desc)
        {
            return base.DescExtended(desc).Replace("&a", ((int)(this.BChar.GetStat.atk * 3.0f)).ToString());
        }
    }
}