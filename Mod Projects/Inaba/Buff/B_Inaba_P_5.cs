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
namespace Inaba
{
	/// <summary>
	/// 炸弹？！
	/// 回合结束时，造成&a(180%)伤害。攻击后将此减益转移至目标身上。
	/// </summary>
    public class B_Inaba_P_5:Buff, IP_SkillUse_Target, IP_TurnEnd
    {
        public void AttackEffect(BattleChar hit, SkillParticle SP, int DMG, bool Cri)
        {
            if (SP.SkillData.Master == this.BChar)
            {
                this.SelfDestroy();
                hit.BuffAdd("B_Inaba_P_5", this.BChar);
            }
        }

        public void TurnEnd()
        {
            Skill skill = Skill.TempSkill("S_Inaba_P_5_0", this.BChar, this.BChar.MyTeam);
            skill.PlusHit = true;
            skill.FreeUse = true;
            BattleSystem.DelayInputAfter(BattleSystem.instance.SkillRandomUseIenum(skill.Master, skill, false, true, false));
            base.SelfDestroy(false);
        }
    }
}