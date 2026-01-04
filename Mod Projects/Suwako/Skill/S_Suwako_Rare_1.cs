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
using BasicMethods;
namespace Suwako
{
    /// <summary>
    /// 蛙狩「蛙以口鸣，方致蛇祸」
    /// 将弃牌库中的所有技能放回牌库，抽取 1 个技能。
    /// <color=#008B45>旋回</color> - 将弃牌库中的所有技能放回牌库。
    /// </summary>
    public class S_Suwako_Rare_1: SkillExtend_Suwako, IP_SkillSelfToDeck
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);
            BattleSystem.DelayInput(this.Del());

            BattleSystem.DelayInput(this.Del2());
        }
        
        private IEnumerator Del()
        {
            int num;
            for (int i = 0; i < BattleSystem.instance.AllyTeam.Skills_UsedDeck.Count; i = num + 1)
            {
                yield return BattleSystem.instance.StartCoroutine(BattleSystem.instance.AllyTeam._UsedDeckToDeck(BattleSystem.instance.AllyTeam.Skills_UsedDeck[i]));
                num = i;
                i = num - 1;
                num = i;
            }
            BattleSystem.instance.AllyTeam.ShuffleDeck();
            yield break;
        }

        private IEnumerator Del2()
        {
            BattleSystem.instance.AllyTeam.Draw();
            yield break;
        }

        public void SelfAddToDeck(SkillLocation skillLoaction)
        {
            BattleSystem.DelayInput(this.Del());
        }
    }
}