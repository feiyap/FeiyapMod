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
namespace FlandreScarlet
{
	/// <summary>
	/// 「掌中的破坏者」
	/// 自身每有1层[禁忌狂乱]，随机从下列效果中生效1项（能多次生效）：
	/// 1，这个技能造成&a(20%)点额外伤害；
	/// 2，超额治疗自己2点体力；
	/// 3，这个技能的命中率和暴击率提升5%。
	/// </summary>
    public class S_FlandreScarlet_5:Skill_Extended
    {
        public int PlusDmg
        {
            get
            {
                if (BattleSystem.instance == null || BattleSystem.instance.BattleLogs == null || BattleSystem.instance.TurnNum <= 0)
                {
                    return 0;
                }
                return (int)((float)(0 + this.BChar.GetStat.atk * 0.4f));
            }
        }

        public override string DescExtended(string desc)
        {
            return base.DescExtended(desc).Replace("&a", (PlusDmg).ToString());
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);

            if (this.BChar.BuffFind("B_FlandreScarlet_P_K", false))
            {
                int count = this.BChar.BuffReturn("B_FlandreScarlet_P_K", false).StackNum;
                for (int i = 0; i < count; i++)
                {
                    int ran = RandomManager.RandomInt(this.BChar.GetRandomClass().Main, 1, 4);
                    switch (ran)
                    {
                        case 1:
                            this.SkillBasePlus.Target_BaseDMG += PlusDmg;
                            break;
                        case 2:
                            this.BChar.Heal(this.BChar, 4, this.BChar.GetCri(), true, null);
                            break;
                        case 3:
                            this.PlusSkillStat.cri += 10f;
                            this.PlusSkillStat.hit += 10f;
                            break;
                    }
                }
            }
        }
    }
}