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
namespace YorigamiSister
{
	/// <summary>
	/// 黄金龙卷风
	/// 若只有 1 个目标，以暴击形式命中。
	/// 这个技能暴击时，消耗 &a 金币(攻击力的135%)。
	/// </summary>
    public class S_Joon_2:Skill_Extended, IP_DamageChange
    {
        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);
            if (Targets.Count == 1)
            {
                this.PlusSkillStat.cri = 999f;
            }
        }

        public int DamageChange(Skill SkillD, BattleChar Target, int Damage, ref bool Cri, bool View)
        {
            if (Cri && !View)
            {
                PlayData.Gold -= (int)(this.BChar.GetStat.atk * 1.35f);
                MasterAudio.PlaySound("SilverStein_Coin", 1f, null, 0f, null, null, false, false);
            }

            return Damage;
        }

        public override string DescExtended(string desc)
        {
            return base.DescExtended(desc).Replace("&a", ((int)(this.BChar.GetStat.atk * 1.35f)).ToString());
        }
    }
}