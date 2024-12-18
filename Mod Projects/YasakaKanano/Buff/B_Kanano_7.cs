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
namespace YasakaKanano
{
	/// <summary>
	/// 冷冽之西风
	/// 回合结束时，若<color=#CD5555>饥馑5</color> - 将本回合释放过的1个技能拿回手中；否则抽取1个技能。
	/// </summary>
    public class B_Kanano_7:Buff, IP_TurnEnd
    {
        public void TurnEnd()
        {
            if (CheckDeck2(5))
            {
                List<Skill> usedList = BattleSystem.instance.BattleLogs.getSkills((BattleLog log) => log.WhoUse.Info.Ally, (Skill skill) => !skill.FreeUse && !skill.isExcept && !skill.Disposable, BattleSystem.instance.TurnNum);

                BattleSystem.DelayInput(BattleSystem.I_OtherSkillSelect(usedList, delegate (SkillButton skillbutton)
                {
                    Skill skill = skillbutton.Myskill.CloneSkill(true, null, null, false);
                    skill.isExcept = true;
                    BattleSystem.instance.AllyTeam.Add(skill, true);
                }, ModManager.getModInfo("YasakaKanano").localizationInfo.SystemLocalizationUpdate("usedSkillSelect"), true, true, true, false, true));
            }
            else
            {
                BattleSystem.instance.AllyTeam.Draw();
            }

            SelfDestroy();
        }

        public bool CheckDeck2(int count)
        {
            return BattleSystem.instance.AllyTeam.Skills_Deck.Count <= count;
        }
    }
}