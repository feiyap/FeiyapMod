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
namespace saber
{
    public class Saber_jiejie_A:Buff, IP_SkillUse_Target
    {
        public override void Init()
        {
            base.Init();
            this.PlusStat.IgnoreTaunt = true;
            this.PlusStat.cri = (float)(20f * base.StackNum);
            this.PlusStat.PlusCriDmg = (int)(float)(50f * base.StackNum);
            this.PlusStat.dod = (int)(10 * base.StackNum);
            this.PlusPerStat.Damage = (int)(25 * base.StackNum);
            this.PlusStat.AggroPer = -33;
        }
        public void AttackEffect(BattleChar hit, SkillParticle SP, int DMG, bool Cri)
        {
            if (hit.HP >= 1 && base.StackNum >= 1 && SP.SkillData.IsDamage && hit.BuffAdd(ModItemKeys.Buff_Saber_fengshi, base.Usestate_F, false, 0, false, -1, false) != null)
            {
            
            }
        }
    }
}