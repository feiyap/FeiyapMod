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
namespace HakureiReimu
{
	/// <summary>
	/// 造成的伤害+50%并且无视防御。
	/// </summary>
    public class SE_HakureiReimu_2: BuffSkillExHand, IP_DamageChange
    {
        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
            this.PlusStat.Penetration = 100;
        }

        public int DamageChange(Skill SkillD, BattleChar Target, int Damage, ref bool Cri, bool View)
        {
            this.OnePassive = true;
            if (SkillD.IsDamage)
            {
                return Damage += BattleChar.CalculationResult((float)this.MySkill.TargetDamageOriginal, 50, 0);
            }
            return Damage;
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);
            if (SkillD.IsDamage)
            {
                BattleSystem.DelayInputAfter(this.Del());
            }
        }

        private IEnumerator Del()
        {
            yield return new WaitForFixedUpdate();
            this.MainBuff.SelfDestroy(false);
            yield break;
        }
    }
}