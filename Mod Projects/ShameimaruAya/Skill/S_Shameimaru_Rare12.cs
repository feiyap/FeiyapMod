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
namespace ShameimaruAya
{
	/// <summary>
	/// 龙卷「天孙降临的道标」
	/// <b><color=green>连击2</color></b> - 附加无视嘲讽。
	/// <b><color=green>连击4</color></b> - 费用增加1点。附加迅速、致命。
	/// <b><color=green>连击6</color></b> - 改为指向所有敌人。
	/// <b><color=green>连击8</color></b> - 费用增加1点。如果仅有1个目标，额外造成&a(150%)伤害。
	/// <b><color=green>连击10</color></b> - 额外造成&a(75%)伤害。
	/// </summary>
    public class S_Shameimaru_Rare12: SE_Shameimaru_Combo
    {
        public override void Init()
        {
            base.Init();
            this.SkillParticleObject = new GDESkillExtendedData(GDEItemKeys.SkillExtended_Public_1_Ex).Particle_Path;
        }

        public int fixCount = 0;

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            fixCount++;
            if (fixCount >= 12)
            {
                fixCount = 0;
                if (CheckUsedSkills(20))
                {
                    base.SkillParticleOn();
                }
                else
                {
                    base.SkillParticleOff();
                }

                this.SkillBasePlus.Target_BaseDMG = (int)(this.BChar.GetStat.atk * 0.15f) * BattleSystem.instance.BattleLogs.getSkills((BattleLog log) => log.WhoUse.Info.Ally, (Skill skill) => !skill.FreeUse, BattleSystem.instance.TurnNum).Count;

                if (CheckUsedSkills(20))
                {
                    this.MySkill.MySkill.Target = new GDEs_targettypeData(GDEItemKeys.s_targettype_all_enemy);
                }
            }
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            this.SkillBasePlus.Target_BaseDMG = (int)(this.BChar.GetStat.atk * 0.15f) * BattleSystem.instance.BattleLogs.getSkills((BattleLog log) => log.WhoUse.Info.Ally, (Skill skill) => !skill.FreeUse, BattleSystem.instance.TurnNum).Count;
        }

        public override string DescExtended(string desc)
        {
            return base.DescExtended(desc).Replace("&a", ((int)(this.BChar.GetStat.atk * 0.15f)).ToString());
        }
    }
}