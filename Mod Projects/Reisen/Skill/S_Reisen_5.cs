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
namespace Reisen
{
	/// <summary>
	/// 幻弹「幻想视差(Bluff Barrage)」
	/// 受到&a(20%最大体力值)的痛苦伤害。
	/// 幻象/狂气 - 抽取1个自己的攻击技能。
	/// </summary>
    public class S_Reisen_5:Skill_Extended
    {
        public int PlusDmg
        {
            get
            {
                return (int)((float)(0 + this.BChar.GetStat.maxhp * 0.2f));
            }
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            this.BChar.Damage(this.BChar, PlusDmg, false, true, false, 0, false, false, false);

            if (this.BChar.BuffFind("B_Reisen_P", false) || this.BChar.BuffFind("B_Reisen_6", false))
            {
                BattleTeam.DrawInput a = null;
                Skill skill2 = BattleSystem.instance.AllyTeam.Skills_Deck.Find((Skill skill) => (skill.Master == this.BChar));
                if (skill2 == null)
                {
                    BattleSystem.instance.AllyTeam.Draw();
                }
                else
                {
                    BattleSystem.instance.AllyTeam.ForceDraw(skill2, a);
                }
            }
        }

        public override string DescExtended(string desc)
        {
            return base.DescExtended(desc).Replace("&a", (PlusDmg).ToString());
        }
    }
}