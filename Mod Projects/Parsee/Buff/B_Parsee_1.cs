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
	/// 对华丽的仁者之嫉妒
	/// 受到下一次攻击的暴击率+100%，受到暴击伤害后解除。
	/// 攻击命中后若目标依然存活，则对目标施加同名诅咒。成功施加诅咒时解除。
	/// </summary>
    public class B_Parsee_1:Buff, IP_Hit, IP_SkillUse_Target
    {
        public override void BuffStat()
        {
            this.PlusStat.crihit = 100;
            base.BuffStat();
        }

        public void Hit(SkillParticle SP, int Dmg, bool Cri)
        {
            if (Cri && Dmg >= 1)
            {
                SelfDestroy();
            }
        }

        public void AttackEffect(BattleChar hit, SkillParticle SP, int DMG, bool Cri)
        {
            if (hit.HP >= 1 && base.StackNum >= 1 && SP.SkillData.IsDamage && hit.BuffAdd("B_Parsee_1", base.Usestate_F, false, 0, false, -1, false) != null)
            {
                base.SelfStackDestroy();
            }
        }
    }
}