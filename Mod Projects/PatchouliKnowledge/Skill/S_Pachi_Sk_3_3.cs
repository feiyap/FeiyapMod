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
namespace PatchouliKnowledge
{
	/// <summary>
	/// 火符「火神之光」
	/// 这个技能无视防御。
	/// 每个等级的“火”使这个技能额外造成&a点伤害(攻击力的20%)。
	/// </summary>
    public class S_Pachi_Sk_3_3:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            this.PlusSkillStat.Penetration = 100f;

            this.SkillBasePlus.Target_BaseDMG = (int)(this.BChar.GetStat.atk * (0.2 * BattleSystem.instance.GetBattleValue<BV_Pachi_P>().elementLevel[3]));
        }

        public override string DescExtended(string desc)
        {
            return base.DescExtended(desc).Replace("&a", ((int)(this.BChar.GetStat.atk * 0.2f)).ToString());
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            this.SkillBasePlus.Target_BaseDMG = (int)(this.BChar.GetStat.atk * (0.2 * BattleSystem.instance.GetBattleValue<BV_Pachi_P>().elementLevel[3]));
        }
    }
}