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
namespace MinamiRio
{
	/// <summary>
	/// KIOSK
	/// 抽取2个技能。
	/// 如果金币超过300，自动消耗300金币获得1个随机药水。
	/// </summary>
    public class S_MinamiRio_LucyD:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            BattleSystem.instance.AllyTeam.Draw(2);

            if (PlayData.Gold > 300)
            {
                PlayData.Gold -= 300;

                MasterAudio.PlaySound("GlassBottles", 1f, null, 0f, null, null, false, false);
                InventoryManager.Reward(InventoryManager.RewardKey(GDEItemKeys.Reward_R_GetPotion, false));
            }
        }
    }
}