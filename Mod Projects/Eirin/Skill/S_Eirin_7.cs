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
namespace Eirin
{
	/// <summary>
	/// 觉神「神话时代的记忆」
	/// 优先抽取1个目标的技能。
	/// 如果抽取的技能为指向单体的攻击技能，为技能的拥有者施加1层[月人/新月]；
	/// 若不是，将这个技能放回牌堆底，再抽取1个技能。
	/// </summary>
    public class S_Eirin_7:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);

            MySkill.MySkill.Effect_Target.Buffs.Clear();
            this.TargetBuff.Clear();

            BattleSystem.DelayInputAfter(this.Draw(Targets[0]));
        }

        public void DrawInput(Skill skill)
        {
            if (skill.MySkill.Target.Key == GDEItemKeys.s_targettype_all_onetarget || skill.MySkill.Target.Key == GDEItemKeys.s_targettype_enemy)
            {
                skill.Master.BuffAdd("B_Eirin_P", this.BChar, false, 0, false, -1, false);
            }
            else
            {
                BattleSystem.instance.AllyTeam.Skills.Remove(skill);
                BattleSystem.instance.AllyTeam.Skills_Deck.Insert(BattleSystem.instance.AllyTeam.Skills_Deck.Count - 1, skill);
                BattleSystem.instance.AllyTeam.Draw();
            }
        }

        public IEnumerator Draw(BattleChar battlechar)
        {
            Skill skill2 = BattleSystem.instance.AllyTeam.Skills_Deck.Find((Skill skill) => (skill.Master == battlechar));
            if (skill2 == null)
            {
                yield return BattleSystem.instance.AllyTeam._Draw(new BattleTeam.DrawInput(this.DrawInput));
            }
            else
            {
                yield return BattleSystem.instance.StartCoroutine(BattleSystem.instance.AllyTeam._ForceDraw(skill2, new BattleTeam.DrawInput(this.DrawInput)));
            }
            yield return null;
            yield break;
        }
    }
}