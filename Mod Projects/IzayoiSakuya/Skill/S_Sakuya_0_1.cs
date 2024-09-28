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
	/// 调换魔术·黑
	/// 将技能放在手牌顶。
	/// </summary>
    public class S_Sakuya_0_1:Skill_Extended
    {
        public override void SkillTargetSingle(List<Skill> Targets)
        {
            base.SkillTargetSingle(Targets);

            //BattleSystem.instance.AllyTeam.Skills.Remove(Targets[0]);
            //BattleSystem.instance.AllyTeam.Skills.Insert(0, Targets[0]);
            //BattleSystem.instance.AllyTeam._Add(Targets[0], true, 0);
            BattleSystem.DelayInputAfter(this.MoveUp(Targets[0]));
        }

        public IEnumerator MoveUp(Skill Temp)
        {
            if (BattleSystem.instance.AllyTeam.Skills.Remove(Temp))
            {
                yield return BattleSystem.instance.ActAfter();
                int num = 0;
                yield return BattleSystem.instance.StartCoroutine(BattleSystem.instance.AllyTeam._Add(Temp, true, num));
            }
            yield break;
        }
    }
}