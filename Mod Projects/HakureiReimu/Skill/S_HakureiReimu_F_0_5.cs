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
	/// 神灵「梦想封印」
	/// 这个技能造成伤害的30%将会转化为自己的保护罩。
	/// 重复释放1次。
	/// </summary>
    public class S_HakureiReimu_F_0_5: S_HakureiReimu_F_0, IP_SkillUse_Target
    {
        public void AttackEffect(BattleChar hit, SkillParticle SP, int DMG, bool Cri)
        {
            if (DMG >= 1)
            {
                Debug.Log(DMG);
                Debug.Log((int)Misc.PerToNum((float)DMG, 50f));
                this.BChar.BuffAdd("B_HakureiReimu_F_0_1", this.BChar, false, 0, false, -1, false);
                this.BChar.BuffReturn("B_HakureiReimu_F_0_1", false).BarrierHP += (int)Misc.PerToNum((float)DMG, 50f);
            }
        }
    }
}