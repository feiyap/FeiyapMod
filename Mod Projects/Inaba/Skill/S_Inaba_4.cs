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
namespace Inaba
{
	/// <summary>
	/// 「远古的骗术」
	/// 如果目标身上有3个以上弱化减益，抽取1个技能。
	/// </summary>
    public class S_Inaba_4: SE_Inaba_Draw
    {
        public override bool CanIgnoreTauntTarget(BattleChar IgnoreTauntTarget)
        {
            return IgnoreTauntTarget.GetBuffs(BattleChar.GETBUFFTYPE.DEBUFF, false, false).Count != 0 || base.CanIgnoreTauntTarget(IgnoreTauntTarget);
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);
            
            foreach (BattleChar bc in Targets)
            {
                foreach (Buff buff in bc.GetBuffs(BattleChar.GETBUFFTYPE.DEBUFF, false))
                {
                    buff.AddBuffEx(new S_Inaba_4_BuffEx());
                    bc.Damage(this.BChar, (int)(this.BChar.GetStat.atk * 0.1 * buff.StackNum), false, true);
                    foreach (StackBuff stackBuff in buff.StackInfo)
                    {
                        stackBuff.RemainTime++;
                        stackBuff.RemainTime++;
                    }
                    buff.BuffStatUpdate();
                }
            }
        }

        public override string DescExtended(string desc)
        {
            return base.DescExtended(desc).Replace("&a", (this.plusHit).ToString());
        }

        public int plusHit
        {
            get
            {
                return (int)((float)(this.BChar.GetStat.atk * 0.1));
            }
        }
    }
}