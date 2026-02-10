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
	/// 剑吻
	/// 受到伤害时，对随机敌人发起反击，造成 &a 伤害(攻击力的75%)。
	/// </summary>
    public class B_FeiyapTank_6:Buff, IP_DamageTake
    {
        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
        }

        public void DamageTake(BattleChar User, int Dmg, bool Cri, ref bool resist, bool NODEF = false, bool NOEFFECT = false, BattleChar Target = null)
        {
            if (Target == this.BChar)
            {
                BattleSystem.DelayInputAfter(this.Attack());
            }
        }

        public IEnumerator Attack()
        {
            yield return new WaitForSecondsRealtime(0.25f);

            Skill skill = Skill.TempSkill("S_FeiyapTank_6_0", this.BChar, this.BChar.MyTeam);
            skill.isExcept = true;
            skill.FreeUse = true;
            skill.PlusHit = true;

            if (BattleSystem.instance.EnemyTeam.AliveChars.Count != 0)
            {
                this.BChar.ParticleOut(skill, BattleSystem.instance.EnemyTeam.AliveChars.Random(this.BChar.GetRandomClass().Main));
            }

            yield break;
        }

        public override string DescExtended()
        {
            return this.BuffData.Description.Replace("&a", ((int)(this.BChar.GetStat.atk * 0.75f)).ToString());
        }
    }
}