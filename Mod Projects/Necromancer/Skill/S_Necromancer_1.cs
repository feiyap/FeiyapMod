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
namespace Necromancer
{
	/// <summary>
	/// 血猩祭祀
	/// 若该伤害使自身濒死，将固定能力替换为吞血之渊。
	/// </summary>
    public class S_Necromancer_1:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);
            BChar.Damage(BChar, BChar.Info.LV, false, true);
        }
        public override void AttackEffectSingle(BattleChar hit, SkillParticle SP, int DMG, int Heal)
        {
            if (BChar.HP <= 0)
            {
                Skill skill = Skill.TempSkill("S_P_Necromancer_1", BChar, BChar.MyTeam);

                (BChar as BattleAlly).MyBasicSkill.SkillInput(skill);
            }
        }
        public override string DescExtended(string desc)
        {
            return desc.Replace("&a", BChar.Info.LV.ToString());
        }
    }
}