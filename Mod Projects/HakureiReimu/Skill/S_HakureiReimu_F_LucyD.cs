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
namespace HakureiReimu
{
	/// <summary>
	/// 御札「神社繁盛祈愿札」
	/// 抽取2个技能。随机施加1个增益效果：
	/// 「繁盛祈愿」下个回合开始时，优先抽取1个自己的技能。
	/// 「幸福祈愿」2回合。+10%攻击力、+10%暴击率。
	/// 「健康祈愿」3回合。6HOT。
	/// 「平安祈愿」闪避下1次受到的伤害。
	/// 如果当前回合数不小于5，改为随机施加2个增益效果。
	/// </summary>
    public class S_HakureiReimu_F_LucyD:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            BattleSystem.instance.AllyTeam.Draw(2);

            int ran = RandomManager.RandomInt(this.BChar.GetRandomClass().Main, 0, 4);
            switch (ran)
            {
                case 0:
                    Targets[0].BuffAdd("B_HakureiReimu_F_LucyD_0", this.BChar);
                    break;
                case 1:
                    Targets[0].BuffAdd("B_HakureiReimu_F_LucyD_1", this.BChar);
                    break;
                case 2:
                    Targets[0].BuffAdd("B_HakureiReimu_F_LucyD_2", this.BChar);
                    break;
                case 3:
                    Targets[0].BuffAdd("B_HakureiReimu_F_LucyD_3", this.BChar);
                    break;
            }

            if (BattleSystem.instance.TurnNum >= 5)
            {
                int ran2 = RandomManager.RandomInt(this.BChar.GetRandomClass().Main, 0, 4);
                while (ran2 == ran)
                {
                    ran2 = RandomManager.RandomInt(this.BChar.GetRandomClass().Main, 0, 4);
                }
                switch (ran2)
                {
                    case 0:
                        Targets[0].BuffAdd("B_HakureiReimu_F_LucyD_0", this.BChar);
                        break;
                    case 1:
                        Targets[0].BuffAdd("B_HakureiReimu_F_LucyD_1", this.BChar);
                        break;
                    case 2:
                        Targets[0].BuffAdd("B_HakureiReimu_F_LucyD_2", this.BChar);
                        break;
                    case 3:
                        Targets[0].BuffAdd("B_HakureiReimu_F_LucyD_3", this.BChar);
                        break;
                }
            }
        }
    }
}