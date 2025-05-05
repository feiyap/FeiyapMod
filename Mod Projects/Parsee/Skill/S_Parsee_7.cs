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
namespace Parsee
{
	/// <summary>
	/// 嫉妒「嫉妒炸弹」
	/// 额外造成&a点伤害[50%治疗力]。
	/// 释放时，每有1层妒火，额外将1张0费迅速的嫉妒炸弹加入手牌，附带放逐、1回合后弃牌。
	/// </summary>
    public class S_Parsee_7:Skill_Extended
    {
        public int PlusDmg
        {
            get
            {
                if (BattleSystem.instance == null || BattleSystem.instance.BattleLogs == null || BattleSystem.instance.TurnNum <= 0)
                {
                    return 0;
                }
                return (int)((float)(0 + this.BChar.GetStat.reg * 0.5));
            }
        }

        public override void Init()
        {
            base.Init();
            this.SkillBasePlus.Target_BaseDMG = this.PlusDmg;
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            this.SkillBasePlus.Target_BaseDMG = this.PlusDmg;
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);
            this.SkillBasePlus.Target_BaseDMG = this.PlusDmg;

            int stack = this.BChar.BuffReturn("B_Parsee_P")?.StackNum ?? 0;

            for (int i = 0; i < stack; i++)
            {
                Skill tmpSkill = Skill.TempSkill("S_Parsee_7", this.BChar, this.BChar.MyTeam);
                tmpSkill.isExcept = true;
                tmpSkill.AutoDelete = 1;
                BattleSystem.instance.AllyTeam.Add(tmpSkill, true);
            }
        }

        public override string DescExtended(string desc)
        {
            return base.DescExtended(desc).Replace("&a", (this.PlusDmg).ToString());
        }
    }
}