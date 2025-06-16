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
namespace Ralmia2
{
	/// <summary>
	/// 毁灭的创造物β
	/// 握在手中时，每当回合结束，对随机敌人造成 &a 伤害(攻击力的150%)。
	/// </summary>
    public class S_Ralmia2_Ex_5: SkillEn_Ralmia_0, IP_TurnEnd
    {
        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
        }

        public void TurnEnd()
        {
            BattleSystem.DelayInputAfter(this.Ienum());
        }

        public IEnumerator Ienum()
        {
            Skill skill = Skill.TempSkill("S_Ralmia2_Ex_5_0", this.BChar, this.BChar.MyTeam);
            skill.isExcept = true;
            skill.FreeUse = true;
            skill.PlusHit = true;
            skill.NoAttackTimeWait = true;
            this.BChar.ParticleOut(skill, BattleSystem.instance.EnemyTeam.AliveChars.Random(this.BChar.GetRandomClass().Main));
            yield return new WaitForSecondsRealtime(0.1f);
            yield break;
        }

        public override string DescExtended(string desc)
        {
            return base.DescExtended(desc).Replace("&a", ((int)(this.BChar.GetStat.atk * 1.5f)).ToString());
        }
    }
}