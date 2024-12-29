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
	/// 完美冻结巫女
	/// 自身可以在冻结状态下行动，造成伤害时额外施加1层[冻伤]。
	/// </summary>
    public class B_Musoutensei_Cirno_0:Buff, IP_SkillUse_Target
    {
        public override void Init()
        {
            base.Init();
            this.PlusStat.Penetration = 100f;
        }

        public void AttackEffect(BattleChar hit, SkillParticle SP, int DMG, bool Cri)
        {
            if (SP.SkillData.IsDamage)
            {
                hit.BuffAdd("B_Cirno_0", base.Usestate_F, false, 0, false, -1, false);
            }
        }
    }
}