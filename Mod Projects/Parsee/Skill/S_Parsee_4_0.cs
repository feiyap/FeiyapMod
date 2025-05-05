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
namespace Parsee
{
	/// <summary>
	/// 乙姬之恋
	/// 所有队员持有的增益持续时间增加 1 回合。
	/// 生成一张“地底桥姬”。
	/// </summary>
    public class S_Parsee_4_0:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);
            foreach (BattleChar battleChar in Targets)
            {
                foreach (Buff buff in battleChar.Buffs)
                {
                    if (!buff.BuffData.Hide)
                    {
                        if (buff.BuffData.Debuff)
                        {

                        }
                        else if (buff.BuffData.LifeTime != 0f)
                        {
                            if (!buff.BuffExtended.Any((Buff_Ex p) => p is BuffEx_Prime_S_3))
                            {
                                foreach (StackBuff stackBuff in buff.StackInfo)
                                {
                                    stackBuff.RemainTime++;
                                }
                                buff.AddBuffEx(new BuffEx_Prime_S_3());
                            }
                        }
                    }
                }
            }

            Skill tmpSkill = Skill.TempSkill("S_Parsee_4_1", this.BChar, this.BChar.MyTeam);
            BattleSystem.instance.AllyTeam.Add(tmpSkill, true);
        }
    }
}