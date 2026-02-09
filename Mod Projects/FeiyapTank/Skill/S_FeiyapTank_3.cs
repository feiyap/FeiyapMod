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
namespace FeiyapTank
{
    /// <summary>
    /// 天五月
    /// 自己受到伤害时，这个技能的费用降低 1 点。
    /// 居合 - 以倒计时5释放。
    /// </summary>
    public class S_FeiyapTank_3 : Skill_Extended, IP_DamageTake, IP_DiscardBefore
    {
        public void DamageTake(BattleChar User, int Dmg, bool Cri, ref bool resist, bool NODEF = false, bool NOEFFECT = false, BattleChar Target = null)
        {
            if (Dmg > 0 && Target == this.BChar)
            {
                this.APChange -= 1;
            }
        }

        public void DiscardBefore(bool Click, Skill skill, bool HandFullWaste)
        {
            if (!HandFullWaste && skill == this.MySkill)
            {
                Skill tempSkill = skill.CloneSkill(true, skill.Master, null, false);
                tempSkill.Counting = 5;
                BattleSystem.DelayInputAfter(BattleSystem.instance.SkillRandomUseIenum(tempSkill.Master, tempSkill, false, false, false));
            }
        }
    }
}