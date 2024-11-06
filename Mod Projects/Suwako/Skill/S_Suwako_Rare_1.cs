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
	/// 这个技能握在手中时，每次触发<color=#008B45>旋回</color>时，恢复自己&a(20%)体力值，恢复1点法力值，并使这个技能向上移动一次。到达手牌最上方后，丢弃这个技能。
	/// </summary>
    public class S_Suwako_Rare_1: SkillExtend_Suwako, IP_OnSkillAddToDeck
    {
        public override string DescExtended(string desc)
        {
            return base.DescExtended(desc).Replace("&a", ((int)(this.BChar.GetStat.atk * 0.2)).ToString());
        }

        private bool terms;

        public override void Init()
        {
            base.Init();
            this.terms = false;
            this.OnePassive = true;
        }

        public IEnumerator OnSkillAddToDeck(Dictionary<Skill, SkillLocation> AddToDeck_Skills)
        {
            yield return null;

            this.BChar.Heal(this.BChar, (int)(this.BChar.GetStat.atk * 0.3), 0, 0);
            BattleSystem.instance.AllyTeam.AP++;

            int num2 = 0;
            while (num2 < BattleSystem.instance.AllyTeam.Skills.Count && BattleSystem.instance.AllyTeam.Skills[num2] != this.MySkill)
            {
                num2++;
            }
            BattleSystem.DelayInputAfter(this.MoveUp(this.MySkill, num2, 1));

            yield return null;
            yield break;
        }

        public IEnumerator MoveUp(Skill Temp, int Originalpos, int MoveNum)
        {
            if (MoveNum > 0 && BattleSystem.instance.AllyTeam.Skills.Remove(Temp))
            {
                yield return BattleSystem.instance.ActAfter();
                int num = Originalpos - (MoveNum + 1);
                if (num <= -1)
                {
                    num = 0;
                }
                yield return BattleSystem.instance.StartCoroutine(BattleSystem.instance.AllyTeam._Add(Temp, true, num));
            }
            yield break;
        }

        public override void TickUpdate()
        {
            base.TickUpdate();
            if (!this.terms && BattleSystem.instance.AllyTeam.Skills.Count >= 1 && this.MySkill.MyButton.gameObject != null && BattleSystem.instance.AllyTeam.Skills[0] == this.MySkill)
            {
                BattleSystem.DelayInputAfter(this.Del());
                this.terms = true;
            }
        }
        
        public IEnumerator Del()
        {
            yield return new WaitForFixedUpdate();

            this.MySkill.Delete();

            yield break;
        }
    }
}