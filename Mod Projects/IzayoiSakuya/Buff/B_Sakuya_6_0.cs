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
namespace IzayoiSakuya
{
	/// <summary>
	/// 幻惑效应
	/// 受到攻击时，咲夜会对来源进行一次&a伤害的反击<color=#FF7A33>(攻击力的30%)</color>。
	/// </summary>
    public class B_Sakuya_6_0:Buff, IP_Hit
    {
        public void Hit(SkillParticle SP, int Dmg, bool Cri)
        {
            if (Dmg > 0 && !SP.SkillData.Master.Info.Ally)
            {
                Skill skill = Skill.TempSkill("S_Sakuya_Knife", this.BChar, this.BChar.MyTeam);
                skill.isExcept = true;
                skill.FreeUse = true;
                skill.PlusHit = true;

                if (SP.SkillData.Master != null || SP.SkillData.Master.IsDead)
                {
                    BattleSystem.instance.StartCoroutine(BattleSystem.instance.ForceAction(skill, SP.SkillData.Master, false, false, false, null));
                }
                else if (BattleSystem.instance.EnemyTeam.AliveChars.Count != 0)
                {
                    BattleSystem.instance.StartCoroutine(BattleSystem.instance.ForceAction(skill, BattleSystem.instance.EnemyTeam.AliveChars.Random(this.BChar.GetRandomClass().Main), false, false, false, null));
                }

                SelfStackDestroy();
            }
        }

        public override string DescInit()
        {
            return base.DescInit().Replace("&a", ((int)(base.BChar.GetStat.atk * 0.3f)).ToString());
        }
    }
}