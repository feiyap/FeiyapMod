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
    /// 使所有其他技能返回牌库。那之后，每个返回牌库的技能使这个技能造成额外&a(60%)伤害。
    /// </summary>
    public class S_Suwako_Rare_1: SkillExtend_Suwako
    {
        public override string DescExtended(string desc)
        {
            return base.DescExtended(desc).Replace("&a", ((int)(this.BChar.GetStat.atk * 0.6)).ToString());
        }

        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            BattleSystem.DelayInput(Del());
            this.SkillBasePlus.Target_BaseDMG = BattleSystem.instance.AllyTeam.Skills.Count * (int)(this.BChar.GetStat.atk * 1.0);
        }

        private IEnumerator Del()
        {
            yield return new WaitForFixedUpdate();

            int num = 0;
            int num2;
            for (num2 = 0; num2 < BattleSystem.instance.AllyTeam.Skills.Count; num2++)
            {
                System.Random random = new System.Random();
                int randomIndex = random.Next(0, this.BChar.MyTeam.Skills_Deck.Count);

                yield return CustomMethods.I_SkillBackToDeck(BattleSystem.instance.AllyTeam.Skills[num2], randomIndex, true);
                num++;
                num2--;
            }

            yield return new WaitForFixedUpdate();
            yield return new WaitForSeconds(0.5f);
        }
    }
}