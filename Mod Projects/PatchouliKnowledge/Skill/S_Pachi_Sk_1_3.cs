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
	/// 木火符「森林大火」
	/// 释放时对所有敌人造成痛苦伤害，伤害量等于目标持有的减益的每回合伤害量。
	/// 每个等级的“火”使这个技能额外造成&a点伤害(攻击力的10%)。
	/// 每个等级的“木”额外施加1层“森林大火”。
	/// </summary>
    public class S_Pachi_Sk_1_3:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            foreach (BattleChar battleChar in BattleSystem.instance.EnemyTeam.AliveChars)
            {
                int num = 0;
                foreach (Buff buff in battleChar.Buffs)
                {
                    num += buff.DotDMGView();
                }
                battleChar.Damage(BattleSystem.instance.DummyChar, num, false, true, false, 0, false, false, false);
            }

            this.SkillBasePlus.Target_BaseDMG = (int)(this.BChar.GetStat.atk * (0.1 * BattleSystem.instance.GetBattleValue<BV_Pachi_P>().elementLevel[3]));

            for (int i = 0; i < BattleSystem.instance.GetBattleValue<BV_Pachi_P>().elementLevel[1]; i++)
            {
                foreach (BattleChar bc in Targets)
                {
                    bc.BuffAdd("B_Pachi_1_1", this.BChar);
                }
            }
        }

        public override string DescExtended(string desc)
        {
            return base.DescExtended(desc).Replace("&a", ((int)(this.BChar.GetStat.atk * 0.1f)).ToString());
        }
    }
}