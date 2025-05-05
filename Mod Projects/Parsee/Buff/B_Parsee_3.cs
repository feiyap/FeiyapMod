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
	/// 无形怪物的凝视
	/// 根据目标当前的痛苦抵抗率的绝对值，等量增加所受暴击伤害（最多100%）。
	/// 攻击命中后若目标依然存活，则对目标施加同名诅咒。成功施加诅咒时解除。
	/// </summary>
    public class B_Parsee_3:Buff, IP_SkillUse_Target
    {
        public override void Init()
        {
            base.Init();
            this.PlusStat.CRIGetDMG = Math.Min(Math.Abs((int)this.BChar.GetStat.RES_DOT), 100);
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            this.PlusStat.CRIGetDMG = Math.Min(Math.Abs((int)this.BChar.GetStat.RES_DOT), 100);
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