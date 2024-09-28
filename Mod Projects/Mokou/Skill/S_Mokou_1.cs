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
namespace Mokou
{
    /// <summary>
    /// 焰符「自灭火焰大旋风」
    /// 使用时对自己造成<color=purple>5点痛苦伤害</color>.使用后本回合内可再释放一次.
    /// </summary>
    public class S_Mokou_1 : Skill_Extended
    {
        public override string DescExtended(string desc)
        {
            return base.DescExtended(desc).Replace("&a", ((int)(3 * (int)Misc.PerToNum((float)this.BChar.GetStat.atk, 15f))).ToString());
        }
        public override void Init()
        {
            base.Init();
            this.SkillParticleObject = new GDESkillExtendedData(GDEItemKeys.SkillExtended_MissChain_Ex_P).Particle_Path;
        }
        public override void FixedUpdate()
        {
            base.FixedUpdate();
            if (EX_ability.CheckEXburn(2, this.BChar))
            {
                base.SkillParticleOn();
            }
            else
            {
                base.SkillParticleOff();
            }
        }
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);
            if (EX_ability.CheckEXburn(2, this.BChar))
            {
                BattleSystem.instance.AllyTeam.AP += 1;
                EX_ability.UseEXburn(2, this.BChar);
            }
            this.BChar.Damage(this.BChar, 3*(int)Misc.PerToNum((float)this.BChar.GetStat.atk, 15f), false, true, true, 0, false, false, false);
            Skill skill = Skill.TempSkill("S_Mokou_1_0", this.BChar, null);
            skill.AutoDelete = 1;
            skill.isExcept = true;
            BattleSystem.instance.AllyTeam.Add(skill, true);
        }
    }
}