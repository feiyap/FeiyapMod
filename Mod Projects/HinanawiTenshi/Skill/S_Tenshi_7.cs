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
namespace HinanawiTenshi
{
	/// <summary>
	/// 气符「无念无想的境界」
	/// <color=#97FFFF>天启3</color> - 解除自己持有的痛苦、弱化减益。
	/// </summary>
    public class S_Tenshi_7: SkillBase_Tenshi
    {
        public override void FixedUpdate()
        {
            base.FixedUpdate();
            Fixed_count++;

            if (Fixed_count >= 12)
            {
                Fixed_count = 0;

                if (CheckKishi(3, true))
                {
                    base.SkillParticleOn();
                }
                else
                {
                    base.SkillParticleOff();
                }
            }
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);

            BattleSystem.instance.GetBattleValue<BV_Tenshi_P>().Kishi += CheckBuffNum();

            if (CheckKishi(3, false))
            {
                if (this.BChar.GetBuffs(BattleChar.GETBUFFTYPE.DOT, false, false).Count != 0)
                {
                    List<Buff> list = new List<Buff>();
                    foreach (Buff buff in this.BChar.Buffs)
                    {
                        if (buff.BuffData.Debuff && !buff.BuffData.Cantdisable && !buff.BuffData.Hide && !buff.DestroyBuff)
                        {
                            buff.SelfDestroy();
                        }
                    }
                }

                if (this.BChar.GetBuffs(BattleChar.GETBUFFTYPE.DEBUFF, false, false).Count != 0)
                {
                    List<Buff> list = new List<Buff>();
                    foreach (Buff buff in this.BChar.Buffs)
                    {
                        if (buff.BuffData.Debuff && !buff.BuffData.Cantdisable && !buff.BuffData.Hide && !buff.DestroyBuff)
                        {
                            buff.SelfDestroy();
                        }
                    }
                }
            }
        }
    }
}