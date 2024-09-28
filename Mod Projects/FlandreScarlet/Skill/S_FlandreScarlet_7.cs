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
	/// 禁忌「被禁止的游戏」
	/// 受到&a(50%当前体力值)的痛苦伤害。下个回合开始时，优先抽取1个自己的技能。
	/// 如果自身处于濒死状态，不会受到痛苦伤害。
	/// </summary>
    public class S_FlandreScarlet_7:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);

            if (this.BChar.HP > 0)
            {
                this.BChar.Damage(this.BChar, (int)Math.Ceiling(this.BChar.HP * 0.5f), false, true, false, 0, false, false, false);
            }

            this.BChar.BuffAdd("B_FlandreScarlet_7_0", this.BChar, true, 0, false, -1, false);
        }

        public override string DescExtended(string desc)
        {
            return base.DescExtended(desc).Replace("&a", ((int)(this.BChar.HP * 0.5f)).ToString());
        }
    }
}