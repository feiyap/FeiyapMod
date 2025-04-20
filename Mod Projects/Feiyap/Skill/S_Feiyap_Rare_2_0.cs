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
namespace Feiyap
{
	/// <summary>
	/// 星天陨辍
	/// 移除目标持有的所有痛苦减益，并对目标造成 1 次痛苦伤害，伤害量为被移除的所有痛苦减益剩余总伤害的值。
	/// 持续时间为永久的痛苦减益在计算时被视为6回合。
	/// </summary>
    public class S_Feiyap_Rare_2_0:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);

            foreach (BattleChar battleChar in Targets)
            {
                int num = 0;
                foreach (Buff buff in battleChar.GetBuffs(BattleChar.GETBUFFTYPE.DOT, false, false))
                {
                    int maxRemain = 0;
                    foreach (StackBuff stackBuff in buff.StackInfo)
                    {
                        if (maxRemain <= stackBuff.RemainTime)
                        {
                            maxRemain = stackBuff.RemainTime;
                        }
                        if (stackBuff.RemainTime <= 0)
                        {
                            maxRemain = 6;
                        }
                    }
                    num += buff.DotDMGView() * maxRemain;
                    //buff.SelfDestroy(false);
                    //battleChar.BuffRemove(buff.BuffData.Key);
                }
                battleChar.Damage(this.BChar, num, false, true, false, 0, false, false, false);
            }
        }
    }
}