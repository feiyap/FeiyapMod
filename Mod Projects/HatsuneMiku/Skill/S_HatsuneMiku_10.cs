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
	/// 荒野と森と魔法の歌
	/// 解除1个负面状态。
	/// 赋予2层[未来之音]。
	/// 赋予等量与目标身上[未来之音]层数的防护罩。
	/// </summary>
    public class S_HatsuneMiku_10:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);

            for (int i = 0; i < Targets.Count; i++)
            {
                //Targets[i].BuffAdd("B_HatsuneMiku_P", this.BChar, false, 0, false, -1, false);
                //Targets[i].BuffAdd("B_HatsuneMiku_P", this.BChar, false, 0, false, -1, false);
                Targets[i].BuffAdd("B_HatsuneMiku_4", this.BChar, false, 0, false, -1, false).BarrierHP += Targets[0].BuffReturn("B_HatsuneMiku_P", false).StackNum;
            }
        }

        public override void AttackEffectSingle(BattleChar hit, SkillParticle SP, int DMG, int Heal)
        {
            S_HatsuneMiku_10.Buffremove(hit);
        }

        // Token: 0x06001025 RID: 4133 RVA: 0x0008C19C File Offset: 0x0008A39C
        public static void Buffremove(BattleChar hit)
        {
            List<Buff> list = new List<Buff>();
            foreach (Buff buff in hit.Buffs)
            {
                if (buff.BuffData.Debuff && !buff.BuffData.Cantdisable && !buff.BuffData.Hide && !buff.DestroyBuff)
                {
                    list.Add(buff);
                }
            }
            if (list.Count != 0)
            {
                hit.BuffRemove(list.Random(hit.GetRandomClass().Main).BuffData.Key, false);
            }
        }
    }
}