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
	/// 风来的奇迹
	/// 下次使用技能时，根据支付的费用，在手中生成相应数量的[北风灵]，移除这个增益。
	/// </summary>
    public class B_Shameimaru_9:Buff, IP_SkillUse_Team
    {
        public override void Init()
        {
            this.PlusStat.dod = 40;
        }

        public void SkillUseTeam(Skill skill)
        {
            if (skill.Master == this.BChar)
            {
                BattleSystem.DelayInputAfter(this.ShameimaruP(skill));
                this.SelfDestroy();
            }
        }

        public IEnumerator ShameimaruP(Skill skill)
        {
            for (int i = 0; i < skill.AP; i++)
            {
                Skill tmpSkill = Skill.TempSkill("S_Shameimaru_P", this.BChar, this.BChar.MyTeam);
                BattleSystem.instance.AllyTeam.Add(tmpSkill, true);
            }

            yield return new WaitForSecondsRealtime(0.3f);
            yield break;
        }
    }
}