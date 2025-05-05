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
	/// 水桥帕鲁西
	/// Passive:
	/// 每当露西外的其他友军使用非生成技能，帕露西点燃1层“妒火”。
	/// 每当帕露西使用非生成技能时，额外对目标施加1层“祸水”。
	/// 妒火层数重置后，帕露西接下来从手中释放的2个技能的伤害量、恢复量增加100％。
	/// </summary>
    public class P_Parsee:Passive_Char, IP_SkillUse_Team_Target
    {
        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
        }

        public void SkillUseTeam_Target(Skill skill, List<BattleChar> Targets)
        {
            if (skill.Master != this.BChar && !skill.Master.IsLucyNoC && !skill.IsCreatedInBattle)
            {
                this.BChar.BuffAdd("B_Parsee_P", this.BChar);
            }

            if (skill.Master == this.BChar && !skill.IsCreatedInBattle)
            {
                foreach (BattleChar bc in Targets)
                {
                    bc.BuffAdd("B_Parsee_P_0", this.BChar);
                }
            }
        }
    }
}