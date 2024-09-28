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
	/// 灵符「梦想封印」
	/// 这个技能造成伤害的10%将会转化为自己的保护罩。
	/// </summary>
    public class S_HakureiReimu_F_0_1: S_HakureiReimu_F_0, IP_SkillUse_Target
    {
        public void AttackEffect(BattleChar hit, SkillParticle SP, int DMG, bool Cri)
        {
            if (SP.SkillData == this.MySkill && DMG >= 1)
            {
                this.BChar.BuffAdd("B_HakureiReimu_F_0_1", this.BChar, false, 0, false, -1, false);
                this.BChar.BuffReturn("B_HakureiReimu_F_0_1", false).BarrierHP += (int)Misc.PerToNum((float)DMG, 10f);
            }
        }
    }
}