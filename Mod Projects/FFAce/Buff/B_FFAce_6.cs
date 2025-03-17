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
namespace FFAce
{
	/// <summary>
	/// 冰晶共鸣
	/// 攻击单个敌人时，为目标施加1层[霜冻]（追加攻击和反击不能触发）。
	/// </summary>
    public class B_FFAce_6:Buff, IP_SkillUse_Target
    {
        public override void Init()
        {
            base.Init();
            this.PlusStat.def = 15;
        }

        public void AttackEffect(BattleChar hit, SkillParticle SP, int DMG, bool Cri)
        {
            if (DMG >= 1 && SP.UseStatus.Info.Ally != hit.Info.Ally && !SP.SkillData.PlusHit && SP.ALLTARGET.Count == 1)
            {
                hit.BuffAdd("B_FFAce_5_1", this.BChar);
            }
        }
    }
}