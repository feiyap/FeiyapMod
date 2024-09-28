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
	/// 稀有抽取
	/// </summary>
    public class S_Kirito_6_0:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            BattleSystem.DelayInputAfter(this.Draw());
        }

        public IEnumerator Draw()
        {
            Skill skill2 = BattleSystem.instance.AllyTeam.Skills_Deck.Find((Skill skill) => skill.MySkill.Rare);
            if (skill2 == null)
            {
                BattleSystem.instance.AllyTeam.Draw();
            }
            else
            {
                yield return BattleSystem.instance.StartCoroutine(BattleSystem.instance.AllyTeam._ForceDraw(skill2, null));
            }
            yield return null;
            yield break;
        }
    }
}