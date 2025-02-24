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
namespace Squall
{
	/// <summary>
	/// SeeD的精锐
	/// 每当有指向友军的攻击技能时，&user承受全部伤害。
	/// 如果指向友军的目标有多个，&user替其承受，受到1/2的伤害
	/// 斯考尔替友军承受伤害时不再获得刃甲
	/// </summary>
    public class B_Squall_Rare_1:Buff, IP_TargetedAlly
    {
        public override void Init()
        {
            base.Init();
            this.PlusStat.def = 18;
            this.PlusStat.Strength = true;
        }

        public IEnumerator Targeted(BattleChar Attacker, List<BattleChar> SaveTargets, Skill skill)
        {
            {
                for (int j = 0; j < SaveTargets.Count; j++)
                {
                    if (SaveTargets[j] != this.BChar)
                    {
                        SaveTargets[j] = this.BChar;
                        EffectView.TextOutSimple(this.BChar, this.BuffData.Name);
                        if (SaveTargets.Count > 1)
                        {
                            this.BChar.BuffAdd("B_Squall_Rare_1_0", this.BChar);
                        }

                        foreach (IP_SaveTargets ip in BattleSystem.instance.IReturn<IP_SaveTargets>())
                        {
                            if (ip != null)
                            {
                                ip.SaveTargets();
                            }
                        }
                    }
                }
            }
            return null;
        }

        public override string DescExtended()
        {
            return base.DescExtended().Replace("&user", this.Usestate_F.Info.Name);
        }
    }
}