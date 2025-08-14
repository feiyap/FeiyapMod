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
namespace Phrolova
{
	/// <summary>
	/// 彼世与彼岸
	/// 造成<color=purple>痛苦伤害</color>。使自身受到<color=purple>&a痛苦伤害</color><color=#FF7A33>(自身最大体力值的100%)</color>。
	/// </summary>
    public class S_Phrolova_Rare_1_2:Skill_Extended, IP_ChangeDamageState
    {
        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            this.BChar.BuffReturn("B_Phrolova_P")?.SelfDestroy();
            this.BChar.Damage(this.BChar, (int)(this.BChar.GetStat.maxhp), false, true);
        }

        public void ChangeDamageState(SkillParticle SP, BattleChar Target, int DMG, bool Cri, ref bool ToHeal, ref bool ToPain)
        {
            ToPain = true;
        }

        public override string DescExtended(string desc)
        {
            return base.DescExtended(desc).Replace("&a", ((int)(this.BChar.GetStat.maxhp * 1f)).ToString());
        }
    }
}