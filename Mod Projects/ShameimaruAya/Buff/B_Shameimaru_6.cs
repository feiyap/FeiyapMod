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
namespace ShameimaruAya
{
	/// <summary>
	/// 风来的暗鸦
	/// 每次使用0费的技能时，对随机敌人造成&a(30%)伤害。
	/// </summary>
    public class B_Shameimaru_6:Buff, IP_SkillUse_Team
    {
        public void SkillUseTeam(Skill skill)
        {
            if (skill.Master == this.BChar && ((!skill.NotCount && skill.AP <= 1) || skill.AP <= 0))
            {
                BattleSystem.DelayInputAfter(this.Ienum());
            }
        }

        public IEnumerator Ienum()
        {
            yield return new WaitForSecondsRealtime(0.1f);
            Skill skill = Skill.TempSkill("S_Shameimaru_6_0", this.BChar, this.BChar.MyTeam);
            skill.PlusHit = true;
            skill.isExcept = true;
            skill.FreeUse = true;

            this.BChar.ParticleOut(skill, this.BChar.BattleInfo.EnemyList.Random(this.BChar.GetRandomClass().Main));

            yield break;
        }

        public override string DescExtended()
        {
            return base.DescExtended().Replace("&a", ((int)(this.BChar.GetStat.atk * 0.3)).ToString());
        }
    }
}