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
namespace FeiyapBoss
{
	/// <summary>
	/// 明镜止水
	/// 解除自身所有<sprite=1>痛苦减益。受到那些减益的剩余伤害量的痛苦伤害。
	/// </summary>
    public class S_Feiyap_Boss_4:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);

            int num = 0;
            foreach (Buff buff in this.BChar.GetBuffs(BattleChar.GETBUFFTYPE.DOT, true, false))
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
                buff.SelfDestroy();
            }
            this.BChar.Damage(this.BChar, num, false, true, false, 0, false, false, false);
        }
    }
}