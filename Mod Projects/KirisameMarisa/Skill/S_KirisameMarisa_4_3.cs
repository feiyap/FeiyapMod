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
namespace KirisameMarisa
{
	/// <summary>
	/// <color=#00BFFF>危险等级3</color> - 击杀敌人时，以一半的伤害量重复释放 1 次。
	/// </summary>
    public class S_KirisameMarisa_4_3: S_KirisameMarisa_4
    {
        public override void SkillKill(SkillParticle SP)
        {
            base.SkillKill(SP);

            BattleSystem.DelayInput(this.Effect());
        }

        public IEnumerator Effect()
        {
            yield return new WaitForSeconds(0.15f);

            if (BattleSystem.instance.EnemyTeam.AliveChar_GetInstance().Count != 0)
            {
                Skill skill = Skill.TempSkill("S_KirisameMarisa_4_3", this.BChar, this.BChar.MyTeam);
                skill.MySkill.Effect_Target.DMG_Per = 60;
                skill.PlusHit = true;
                this.BChar.ParticleOut(this.MySkill, skill, BattleSystem.instance.EnemyTeam.AliveChars.Random(this.BChar.GetRandomClass().Main));
            }
            yield return new WaitForSeconds(0.1f);

            yield break;
        }
    }
}