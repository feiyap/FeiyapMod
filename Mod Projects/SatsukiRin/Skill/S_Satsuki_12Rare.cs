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
namespace SatsukiRin
{
	/// <summary>
	/// 「False Promise」
	/// 驱散1个减益状态。
	/// </summary>
    public class S_Satsuki_12Rare:Skill_Extended
    {
        public override void AttackEffectSingle(BattleChar hit, SkillParticle SP, int DMG, int Heal)
        {
            MasterAudio.PlaySound("S_Satsuki_12Rare", 1f, null, 0f, null, null, false, false);
            for (int i = 0; i < hit.Buffs.Count; i++)
            {
                if (hit.Buffs[i].BuffData.Debuff && !hit.Buffs[i].CantDisable)
                {
                    hit.Buffs[i].SelfDestroy(false);
                }
            }
        }
    }
}