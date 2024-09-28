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
namespace Kirito
{
	/// <summary>
	/// 蓝蔷薇之剑
	/// 对敌人造成伤害时附加1层[冻伤]。
	/// </summary>
    public class B_Eugeo_P_0:Buff, IP_SkillUse_Target
    {
        public void AttackEffect(BattleChar hit, SkillParticle SP, int DMG, bool Cri)
        {
            if (DMG > 0 && SP.SkillKey != "S_Kirito_P" && SP.SkillKey != "S_Kirito_11Rare_0")
            {
                hit.BuffAdd("B_Eugeo_P_0_0", this.BChar, false, 0, false, -1, false);
            }
        }
    }
}