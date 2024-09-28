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
namespace HouraisanKaguya
{
	/// <summary>
	/// 神宝「蓬莱的玉枝　-梦色之乡-」
	/// 对目标两侧的角色造成50%的溅射伤害。
	/// <color=#ffc1c1>神宝</color> - 施加[辉夜/梦乡]。
	/// </summary>
    public class S_FKaguya_9:Skill_Extended
    {
        public override void Init()
        {
            base.Init();
            this.SkillParticleObject = new GDESkillExtendedData(GDEItemKeys.SkillExtended_Priest_Ex_P).Particle_Path;
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();

            if (this.BChar.BuffFind("B_FKaguya_Sinnpou"))
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

            MySkill.MySkill.Effect_Target.Buffs.Clear();
            this.TargetBuff.Clear();

            BattleSystem.DelayInput(this.Damage1(Targets[0].MyLeftCharReturn()));
            BattleSystem.DelayInput(this.Damage1(Targets[0].MyRightCharReturn()));

            if (this.BChar.BuffFind("B_FKaguya_Sinnpou"))
            {
                this.BChar.BuffReturn("B_FKaguya_Sinnpou").SelfDestroy();
                Targets[0].BuffAdd("B_FKaguya_9", this.BChar, false, 0, false, 3, false);
            }
        }
        
        public IEnumerator Damage1(BattleChar Target)
        {
            Skill skill = Skill.TempSkill("S_FKaguya_9_0", this.BChar, this.BChar.MyTeam);
            this.BChar.ParticleOut(skill, Target);
            yield break;
        }
    }
}