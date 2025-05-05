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
	/// 祸水
	/// 攻击命中后若目标依然存活，则(100%<sprite=0>)对目标施加1层<sprite=0>诅咒减益。
	/// 成功施加诅咒时减少1层。
	/// </summary>
    public class B_Parsee_P_0:Buff, IP_SkillUse_Target
    {
        public override void Init()
        {
            base.Init();
            this.PlusStat.HEALTaken = -15 * StackNum;
            this.PlusStat.RES_CC = -15 * StackNum;
            this.PlusStat.RES_DOT = -15 * StackNum;
            this.PlusStat.RES_DEBUFF = -15 * StackNum;
        }

        public void AttackEffect(BattleChar hit, SkillParticle SP, int DMG, bool Cri)
        {
            if (hit.HP >= 1 && base.StackNum >= 1 && SP.SkillData.IsDamage && hit.BuffAdd("B_Parsee_P_1", base.Usestate_F, false, 0, false, -1, false) != null)
            {
                base.SelfStackDestroy();
            }
        }
    }
}