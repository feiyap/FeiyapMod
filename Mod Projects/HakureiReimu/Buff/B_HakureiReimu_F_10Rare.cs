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
namespace HakureiReimu
{
	/// <summary>
	/// 梦想天生
	/// 使用7张攻击技能后，移除该BUFF，对随机敌人造成20次%a(30%)伤害。
	/// </summary>
    public class B_HakureiReimu_F_10Rare:Buff, IP_SkillUseHand_Team
    {
        public int count;
        public override void Init()
        {
            base.Init();
            count = 0;
        }

        public void SKillUseHand_Team(Skill skill)
        {
            if (skill.Master == this.BChar)
            {
                count++;
                if (count >= 7)
                {
                    MasterAudio.PlaySound("Musoutensei", 1f, null, 0f, null, null, false, false);
                    for (int i = 0; i < 20; i++)
                    {
                        BattleSystem.DelayInput(this.Effect());
                    }
                    SelfDestroy();
                }
            }
        }

        public IEnumerator Effect()
        {
            Skill skill = Skill.TempSkill("S_HakureiReimu_F_10Rare_0", this.BChar, this.BChar.MyTeam);
            skill.PlusHit = true;
            this.BChar.ParticleOut(skill, this.BChar.BattleInfo.EnemyList.Random(this.BChar.GetRandomClass().Main));

            yield return new WaitForSeconds(0.1f);
            yield break;
        }

        public override string DescExtended()
        {
            return base.DescExtended().Replace("&a", ((int)(base.Usestate_L.GetStat.atk * 6.0f)).ToString());
        }
    }
}