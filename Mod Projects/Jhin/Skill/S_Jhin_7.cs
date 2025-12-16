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
namespace Jhin
{
	/// <summary>
	/// 再等等…
	/// 丢弃手中所有自己的技能，将弃牌库中自己的技能洗入牌库。
	/// 那之后，优先抽取那个数量+X的自己的技能。X为这个技能的费用。
	/// 本回合内，自己无法再使用技能。
	/// </summary>
    public class S_Jhin_7:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);

            BattleSystem.DelayInput(this.Del());

            this.BChar.BuffAdd("B_Jhin_7", this.BChar);
        }

        private IEnumerator Del()
        {
            yield return new WaitForFixedUpdate();

            int count = this.MySkill.UsedApNum;

            int num = 0;
            for (int i = 0; i < BattleSystem.instance.AllyTeam.Skills.Count; i++)
            {
                if (BattleSystem.instance.AllyTeam.Skills[i].Master != this.BChar)
                {
                    continue;
                }
                BattleSystem.instance.AllyTeam.Skills[i].Delete(false);
                int num2 = num;
                num = num2 + 1;
                i--;
                count++;
            }

            yield return new WaitForFixedUpdate();
            yield return new WaitForSeconds(0.5f);

            this.BChar.MyTeam.ShuffleDeck();

            for (int i = 0; i < count; i++)
            {
                BattleSystem.instance.AllyTeam.CharacterDraw(this.BChar);
            }

            yield break;
        }
    }
}