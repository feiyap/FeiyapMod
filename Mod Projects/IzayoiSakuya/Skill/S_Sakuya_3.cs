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
namespace IzayoiSakuya
{
	/// <summary>
	/// 幻在「钟表的残骸」
	/// 倒计时1后，再造成%a伤害。
	/// 月魔术 - 倒计时延长为3。倒计时期间，目标受到的伤害增加15%。
	/// </summary>
    public class S_Sakuya_3:Skill_Extended
    {
        public bool flag;
        public bool flag2;

        public override void Init()
        {
            base.Init();
            this.SkillParticleObject = new GDESkillExtendedData(GDEItemKeys.SkillExtended_Public_1_Ex).Particle_Path;
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            if (BattleSystem.instance != null && BattleSystem.instance.AllyTeam.Skills.Count != 0)
            {
                flag = false;
                base.SkillParticleOff();
                this.MySkill.MySkill.Name = "幻在「钟表的残骸」";
                if (this.MySkill == BattleSystem.instance.AllyTeam.Skills[BattleSystem.instance.AllyTeam.Skills.Count - 1]
                    || this.MySkill == BattleSystem.instance.AllyTeam.Skills[0]
                    || this.MySkill.ExtendedFind_DataName("SE_Sakuya_7") != null
                    || this.BChar.BuffFind("B_Sakuya_12Rare"))
                {
                    flag = true;
                    base.SkillParticleOn();
                    this.MySkill.MySkill.Name = "幻幽「迷幻的杰克」";
                }
            }
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            if (this.flag)
            {
                flag2 = true;
            }
            else
            {
                flag2 = false;
            }
        }

        public override void AttackEffectSingle(BattleChar hit, SkillParticle SP, int DMG, int Heal)
        {
            if (this.flag2)
            {
                Skill skill = Skill.TempSkill("S_Sakuya_3_1", this.BChar, this.BChar.MyTeam).CloneSkill(false, null, null, false);
                skill.isExcept = true;
                skill.FreeUse = true;
                skill.PlusHit = true;
                BattleSystem.DelayInput(BattleSystem.instance.ForceAction(skill, hit, false, false, true, null));
                this.MySkill.MySkill.Name = "幻幽「迷幻的杰克」";
            }
            else
            {
                Skill skill = Skill.TempSkill("S_Sakuya_3_0", this.BChar, this.BChar.MyTeam).CloneSkill(false, null, null, false);
                skill.isExcept = true;
                skill.FreeUse = true;
                skill.PlusHit = true;
                BattleSystem.DelayInput(BattleSystem.instance.ForceAction(skill, hit, false, false, true, null));
                this.MySkill.MySkill.Name = "幻在「钟表的残骸」";
            }
        }
        
        public override string DescExtended(string desc)
        {
            return base.DescExtended(desc).Replace("%a", ((int)(this.BChar.GetStat.atk * 1.0f)).ToString()).Replace("%b", ((int)(this.BChar.GetStat.atk * 0.2f)).ToString());
        }
    }
}