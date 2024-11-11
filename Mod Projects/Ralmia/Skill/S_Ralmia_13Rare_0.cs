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
namespace Ralmia
{
	/// <summary>
	/// 防御的创造物
	/// 恢复体力极限。清除所有异常状态。
	/// </summary>
    public class S_Ralmia_13Rare_0: SkillEn_Ralmia_0
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);

            if (Targets[0].HP < Targets[0].Recovery)
            {
                int num = Targets[0].Recovery - Targets[0].HP;
                Targets[0].Heal(this.BChar, (float)num, false, false, null);
            }
            for (int i = 0; i < Targets[0].Buffs.Count; i++)
            {
                if (Targets[0].Buffs[i].BuffData.Debuff && !Targets[0].Buffs[i].CantDisable)
                {
                    Targets[0].Buffs[i].SelfDestroy(false);
                }
            }
        }
    }
}