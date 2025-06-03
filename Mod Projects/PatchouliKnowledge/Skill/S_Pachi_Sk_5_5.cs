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
namespace PatchouliKnowledge
{
	/// <summary>
	/// 日符「皇家烈焰」
	/// 根据这场战斗中自身使用过手中的技能的次数，重复释放这个技能。
	/// 当前次数：&a
	/// </summary>
    public class S_Pachi_Sk_5_5:Skill_Extended
    {
        public int ShotNum
        {
            get
            {
                if (BattleSystem.instance != null && BattleSystem.instance.BattleLogs != null && BattleSystem.instance.TurnNum >= 1)
                {
                    return BattleSystem.instance.BattleLogs.getSkills((BattleLog log) => log.WhoUse.Info.Ally, (Skill skill) => !skill.FreeUse && !skill.PlusHit && skill.Master == this.BChar, -1).Count;
                }
                return 0;
            }
        }

        public override void Init()
        {
            base.Init();
        }

        public override void HandInit()
        {
            base.HandInit();
        }

        public override string DescExtended(string desc)
        {
            return base.DescExtended(desc).Replace("&a", this.ShotNum.ToString());
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);
            Skill skill = Skill.TempSkill("S_Pachi_Sk_5_5", this.BChar, this.BChar.MyTeam);
            skill.PlusHit = true;
            skill.FreeUse = true;

            for (int i = 0; i < ShotNum; i++)
            {
                BattleSystem.DelayInput(this.attack(skill));
            }
        }

        public IEnumerator attack(Skill AttackSkill)
        {
            yield return new WaitForSeconds(0.05f);

            this.BChar.ParticleOut(AttackSkill, BattleSystem.instance.EnemyList.Random(this.BChar.GetRandomClass().Main));

            yield return null;
            yield break;
        }
    }
}