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
namespace PatchouliKnowledge
{
	/// <summary>
	/// 木符「风灵的角笛」
	/// 使目标持有的所有痛苦减益扩散至其他敌人。
	/// 指向敌人时，若只存在 1 个敌人，使目标持有的所有痛苦减益持续时间翻倍。
	/// 每个等级的“木”额外施加1层“森林大火”。
	/// </summary>
    public class S_Pachi_Sk_1_1:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            List<BattleChar> list = new List<BattleChar>();
            list.AddRange(BattleSystem.instance.EnemyTeam.AliveChars);
            list.Remove(Targets[0]);

            if (list.Count >= 1)
            {
                foreach (BattleChar bc in list)
                {
                    List<Buff> buffs = Targets[0].GetBuffs(BattleChar.GETBUFFTYPE.DOT, false, false);
                    foreach (Buff buff in buffs)
                    {
                        for (int i = 0; i < buff.StackNum; i++)
                        {
                            bc.BuffAdd(buff.BuffData.Key, buff.Usestate_L);
                        }
                    }
                }
            }

            for (int i = 0; i < BattleSystem.instance.GetBattleValue<BV_Pachi_P>().elementLevel[1]; i++)
            {
                foreach (BattleChar bc in Targets)
                {
                    bc.BuffAdd("B_Pachi_1_1", this.BChar);
                }
            }
        }
    }
}