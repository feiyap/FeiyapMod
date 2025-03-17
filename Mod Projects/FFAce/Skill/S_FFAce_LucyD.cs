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
namespace FFAce
{
	/// <summary>
	/// 共鸣
	/// 抽取2个技能。
	/// 若艾斯的固定能力可使用，恢复1点费用；
	/// 若艾斯的固定能力不可使用，则使艾斯可再次使用固定能力。
	/// 艾斯的下次[翻牌]可额外翻开一张牌并选择1个[翻开]效果使用。
	/// </summary>
    public class S_FFAce_LucyD:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            BattleSystem.instance.AllyTeam.Draw(2);

            using (List<BattleChar>.Enumerator enumerator = BattleSystem.instance.AllyTeam.AliveChars.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    if (enumerator.Current.Info.KeyData == "FFAce")
                    {
                        if (enumerator.Current is BattleAlly && !(enumerator.Current as BattleAlly).MyBasicSkill.InActive)
                        {
                            BattleSystem.instance.AllyTeam.AP++;
                        }
                        else
                        {
                            BattleAlly ba = (enumerator.Current as BattleAlly);
                            ba.MyBasicSkill.CoolDownNum = 0;
                            if (ba.MyBasicSkill.ThisSkillUse)
                            {
                                ba.MyBasicSkill.InActive = false;
                                ba.MyBasicSkill.ThisSkillUse = false;
                            }
                            if (ba.MyBasicSkill.InActive)
                            {
                                ba.MyBasicSkill.InActive = false;
                            }
                        }

                        enumerator.Current.BuffAdd("B_FFAce_LucyD", enumerator.Current);
                    }
                }
            }
        }
    }
}