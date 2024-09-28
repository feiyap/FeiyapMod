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
namespace Mokou
{
	/// <summary>
	/// 灭罪「正直者之死」
	/// 如果倒计时内没有受到目标攻击，则该技能变为aoe释放；如果受到目标攻击，则对双方施加3层烧伤。
	/// </summary>
    public class S_Mokou_3:Skill_Extended, IP_SkillCastingStart
    {
        public override void SkillUseHand(BattleChar Targets)
        {
            if (Targets is BattleEnemy)
            {
                Buff buff = Targets.BuffAdd(GDEItemKeys.Buff_B_Taunt, this.BChar, false, (int)(100f + this.BChar.GetStat.HIT_CC), false, 3, false);
                buff.TimeUseless = false;
                buff.LifeTime = 3;
                buff.StackInfo[0].RemainTime = 3;
            }
        }
        public void SkillCasting(CastingSkill ThisSkill)
        {
            this.BChar.BuffAdd("B_Mokou_S_3", this.BChar, false, 0, false, -1, false);
        }
    }
}