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
namespace RemiliaScarlet
{
	/// <summary>
	/// 红符「红色不夜城」
	/// </summary>
    public class S_RemiliaScarlet_0:Skill_Extended
    {
        public override void Init()
        {
            base.Init();
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);

            for (int i = 0; i < Targets.Count; i++)
            {
                if (Targets[i] is BattleEnemy)
                {
                    if (Targets[i].BuffFind("B_RemiliaScarlet_0", false))
                    {
                        Targets[i].Damage(this.BChar, 5 * Targets[i].BuffReturn("B_RemiliaScarlet_0", false).StackNum, false, true, true, 0, false, false, false);
                        foreach (StackBuff stackBuff in Targets[i].BuffReturn("B_RemiliaScarlet_0", false).StackInfo)
                        {
                            stackBuff.RemainTime++;
                        }
                    }
                }
            }
        }
    }
}