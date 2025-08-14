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
namespace Phrolova
{
	/// <summary>
	/// 生与死的乐章
	/// 重复释放 2 次，并造成<color=purple>痛苦伤害</color>。
	/// 从牌库或弃牌库中抽取 1 个“新世界狂想曲”。
	/// 持有“重世”增益时，还会使目标(<sprite=2>80%)眩晕 1 回合。
	/// </summary>
    public class S_Phrolova_0:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            if (this.BChar.BuffFind("B_Phrolova_2"))
            {
                Targets[0].BuffAdd("B_Common_Rest", this.BChar, false, 80);
            }

            foreach (Skill skill in BattleSystem.instance.AllyTeam.Skills_UsedDeck)
            {
                if (skill.MySkill.KeyID == "S_Phrolova_2")
                {
                    BattleSystem.instance.AllyTeam.ForceDrawF(skill);
                    return;
                }
            }
            foreach (Skill skill2 in BattleSystem.instance.AllyTeam.Skills_Deck)
            {
                if (skill2.MySkill.KeyID == "S_Phrolova_2")
                {
                    BattleSystem.instance.AllyTeam.ForceDrawF(skill2);
                    return;
                }
            }
        }

        public override void AttackEffectSingle(BattleChar hit, SkillParticle SP, int DMG, int Heal)
        {
            base.AttackEffectSingle(hit, SP, DMG, Heal);
            BattleSystem.DelayInputAfter(this.PlusHit(hit, DMG));
            BattleSystem.DelayInputAfter(this.PlusHit(hit, DMG));
        }
        
        public IEnumerator PlusHit(BattleChar TempChar, int DMG)
        {
            Skill skill = Skill.TempSkill("S_Phrolova_0_1", this.BChar, this.BChar.MyTeam);
            Skill_Extended skill_Extended = new Skill_Extended();
            skill_Extended.IsDamage = true;
            skill.MySkill.Effect_Target.DMG_Base = DMG;
            skill.ExtendedAdd(skill_Extended);
            if (this.MySkill.MySkill.Target.Key == GDEItemKeys.s_targettype_ally)
            {
                skill.MySkill.Target = this.MySkill.MySkill.Target;
            }
            if (TempChar != null || TempChar.IsDead)
            {
                yield return BattleSystem.instance.StartCoroutine(BattleSystem.instance.ForceAction(skill, TempChar, false, false, false, null));
            }
            else if (BattleSystem.instance.EnemyTeam.AliveChars.Count != 0)
            {
                yield return BattleSystem.instance.StartCoroutine(BattleSystem.instance.ForceAction(skill, BattleSystem.instance.EnemyTeam.AliveChars.Random(this.BChar.GetRandomClass().Main), false, false, false, null));
            }
            yield break;
        }
    }
}