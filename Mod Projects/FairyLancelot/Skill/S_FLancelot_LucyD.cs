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
namespace FairyLancelot
{
	/// <summary>
	/// 我对你的爱
	/// 复制手中所有技能（稀有技能、露西技能、光之地平线、你已深陷于我、你已无法离开我、你已完全属于我除外），并使其费用转变为 1，附加迅速、放逐。
	/// 如果复制的技能持有者为兰斯洛特，则对兰斯洛特施加持续 1 回合的“保护体力极限”。
	/// 在之后的回合里，每回合开始时额外抽取 2 个技能。
	/// </summary>
    public class S_FLancelot_LucyD:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            BattleSystem.instance.AllyTeam.Draw(2);

            using (List<BattleChar>.Enumerator enumerator = BattleSystem.instance.AllyTeam.AliveChars.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    if (enumerator.Current.Info.KeyData == "FairyLancelot")
                    {
                        PlayData.TSavedata.GetCustomValue<CV_FairyLancelotGood>().heartPoint += 2;
                        if (PlayData.TSavedata.GetCustomValue<CV_FairyLancelotGood>().heartPoint >= 50)
                        {
                            BattleSystem.instance.AllyTeam.Draw();
                        }
                        break;
                    }
                }
            }
        }
    }
}