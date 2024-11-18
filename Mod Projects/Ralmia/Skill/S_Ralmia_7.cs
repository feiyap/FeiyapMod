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
namespace Ralmia
{
    /// <summary>
    /// 创造物的呼唤
    /// 优先抽取2个创造物技能。每少抽取1个创造物技能，回复1点费用。
    /// </summary>
    public class S_Ralmia_7:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            for (int i = 0; i < 2; i++)
            {
                BattleSystem.DelayInputAfter(this.Draw());
            }
        }
        
        public IEnumerator Draw()
        {
            Skill skill2 = BattleSystem.instance.AllyTeam.Skills_Deck.Find((Skill skill) => (skill.ExtendedFind_DataName("SkillEn_Ralmia_2") != null || skill.ExtendedFind_DataName("SE_Ralmia_C_0") != null));
            if (skill2 == null)
            {
                BattleSystem.instance.AllyTeam.Draw();
                BattleTeam allyTeam = BattleSystem.instance.AllyTeam;
                int ap = allyTeam.AP;
                allyTeam.AP = ap + 1;
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