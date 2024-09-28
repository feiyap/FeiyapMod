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
namespace Kirito
{
	/// <summary>
	/// 诗乃
	/// 获得+10%暴击率和+10%暴击伤害。每使用3个技能后触发1次[狙击支援]，并获得1层[刀劈子弹]：闪避1次攻击。
	/// </summary>
    public class B_Shino_P:Buff, IP_SkillUse_User
    {
        int count;

        public override void Init()
        {
            base.Init();
            this.PlusStat.cri = 10f;
            this.PlusStat.PlusCriDmg = 10f;
            count = 0;
        }

        public void SkillUse(Skill SkillD, List<BattleChar> Targets)
        {
            if (!SkillD.BasicSkill)
            {
                count++;
                if (count >= 3)
                {
                    this.BChar.BuffAdd("B_Shino_P_0", this.BChar, false, 0, false, -1, false);
                    BattleSystem.DelayInputAfter(this.Ienum());
                    count = 0;
                }
            }
        }

        public IEnumerator Ienum()
        {
            Skill skill = Skill.TempSkill("S_Shino_0", this.BChar, this.BChar.MyTeam);
            this.BChar.ParticleOut(skill, BattleSystem.instance.EnemyTeam.AliveChars.Random(this.BChar.GetRandomClass().Main));

            yield return new WaitForSecondsRealtime(0.1f);
            yield break;
        }
    }
}