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
namespace Morichika
{
	/// <summary>
	/// 鉴识眼「精益求精的起源」
	/// 抽取 2 个技能。
    /// 若这是本场战斗第 1 次打出，获得 1 个随机卷轴；否则恢复 1 点法力值。
	/// </summary>
    public class S_Morichika_LucyD:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            BattleSystem.instance.AllyTeam.Draw(2);

            if (BattleSystem.instance.BattleLogs.getSkills((BattleLog log) => log.WhoUse.Info.Ally, (Skill skill) => skill.CharinfoSkilldata == this.MySkill.CharinfoSkilldata, -1).Count > 0)
            {
                BattleSystem.instance.AllyTeam.AP++;
            }
            else
            {
                List<ItemBase> list = new List<ItemBase>();
                list.AddRange(InventoryManager.RewardKey(GDEItemKeys.Reward_R_GetScroll, false));
                InventoryManager.Reward(list);
            }
        }
    }
}