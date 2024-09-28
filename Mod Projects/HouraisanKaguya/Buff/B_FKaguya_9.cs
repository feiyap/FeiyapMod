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
	/// 辉夜/梦乡
	/// 受到追加攻击/反击时，辉夜对其进行一次一半数值的追加攻击（不会重复触发）。
	/// </summary>
    public class B_FKaguya_9:Buff, IP_Hit, IP_PlayerTurn
    {
        public int count = 0;

        public override void Init()
        {
            base.Init();
            count = 0;
        }

        public void Turn()
        {
            count = 0;
        }

        public void Hit(SkillParticle SP, int Dmg, bool Cri)
        {
            if (SP.SkillData.PlusHit && SP.SkillKey != "S_FKaguya_9_1" && SP.SkillKey != "S_Inaba_9_0" && count <= 40)
            {
                Skill skill = Skill.TempSkill("S_FKaguya_9_1", base.Usestate_L, this.Usestate_L.MyTeam);
                skill.PlusHit = true;
                skill.MySkill.Effect_Target.DMG_Base = Dmg / 2;
                BattleSystem.DelayInput(this.KaguyaAttack(skill, this.BChar));
                count++;
            }
        }

        public IEnumerator KaguyaAttack(Skill skill, BattleChar hit)
        {
            yield return new WaitForSecondsRealtime(0.1f);
            base.Usestate_L.ParticleOut(skill, hit);
            yield return null;
            yield break;
        }
    }
}