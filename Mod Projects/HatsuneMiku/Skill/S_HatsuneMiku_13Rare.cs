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
namespace HatsuneMiku
{
	/// <summary>
	/// 初音ミクの消失
	/// 使所有队友解除所有减益。
	/// 赋予39层[未来之音]。
	/// 自己死亡。
	/// </summary>
    public class S_HatsuneMiku_13Rare:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);

            for (int i = 0; i < BattleSystem.instance.AllyList.Count; i++)
            {
                for (int j = 0; j < 39; j++)
                {
                    BattleSystem.instance.AllyList[i].BuffAdd("B_HatsuneMiku_P", this.BChar, false, 0, false, -1, false);
                }
            }

            this.BChar.Dead(false, false);
        }

        public override void AttackEffectSingle(BattleChar hit, SkillParticle SP, int DMG, int Heal)
        {
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