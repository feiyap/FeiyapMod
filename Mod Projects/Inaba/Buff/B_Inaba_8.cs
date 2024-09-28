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
namespace Inaba
{
	/// <summary>
	/// 因幡/兔运
	/// 命中时消耗1层，使目标防御力-4%，闪避率-4%。最多叠加5次。
	/// </summary>
    public class B_Inaba_8:Buff, IP_SkillUse_Target
    {
        public override void Init()
        {
            this.PlusPerStat.Damage = 2 * StackNum;
            this.PlusStat.hit = 4 * StackNum;
            this.isStackDestroy = true;
        }

        public override void BuffStat()
        {
            this.PlusPerStat.Damage = 2 * StackNum;
            this.PlusStat.hit = 4 * StackNum;
        }

        public void AttackEffect(BattleChar hit, SkillParticle SP, int DMG, bool Cri)
        {
            if (hit.HP >= 1 && base.StackNum >= 1 && SP.SkillData.IsDamage)
            {
                hit.BuffAdd("B_Inaba_8_0", base.Usestate_F, false, 0, false, -1, false);
                base.StackDestroy();
            }
        }
    }
}