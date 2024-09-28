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
namespace HouraisanKaguya
{
	/// <summary>
	/// 难题「蓬莱的弹枝　-七色的弹幕-」
	/// 随机生成1个目标的专属技能，附带随机强化和放逐。
	/// <color=purple>难题</color> - 上个使用技能的持有者位于自身的左边或右边。
	/// </summary>
    public class S_FKaguya_8:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            for (int i = 0; i < Targets.Count; i++)
            {
                List<GDESkillData> list = new List<GDESkillData>();
                foreach (GDESkillData gdeskillData in PlayData.ALLSKILLLIST)
                {
                    if (gdeskillData.User == Targets[i].Info.KeyData && !gdeskillData.NoDrop && gdeskillData.KeyID != "S_FKaguya_8")
                    {
                        list.Add(gdeskillData);
                    }
                }
                List<GDESkillData> list2 = new List<GDESkillData>();
                list2.AddRange(list.Random(this.BChar.GetRandomClass().Main, 1));
                new List<Skill>();

                BattleSystem.DelayInput(this.Effect(list2, Targets[i]));
            }

            int num2 = 0;
            for (int i = 0; i < BattleSystem.instance.AllyTeam.AliveChars.Count; i++)
            {
                if (BattleSystem.instance.AllyTeam.AliveChars[i] == this.BChar)
                {
                    num2 = i;
                }
            }
            List<BattleAlly> allyList = BattleSystem.instance.AllyList;
            List<BattleChar> list3 = new List<BattleChar>();
            if (num2 != 0)
            {
                list3.Add(allyList[num2 - 1]);
            }
            if (allyList.Count > num2 + 1)
            {
                list3.Add(allyList[num2 + 1]);
            }
            if (list3.Count != 0)
            {
                for (int i = 0; i < list3.Count; i++)
                {
                    if ((BattleSystem.instance.BattleLogs.getLastSkill(false, false, null, (Skill skill) => skill.Master).Master == list3[i]))
                    {
                        this.BChar.BuffAdd("B_FKaguya_Sinnpou", this.BChar, false, 0, false, -1, false);
                    }
                }
            }
        }

        public IEnumerator Effect(List<GDESkillData> list, BattleChar Target)
        {
            foreach (GDESkillData gdeskillData in list)
            {
                Skill skill = Skill.TempSkill(gdeskillData.Key, Target, Target.MyTeam);
                skill.isExcept = true;
                BattleSystem.instance.AllyTeam.Add(skill, true);

                if (!skill.Master.IsLucyNoC && !skill.Enforce)
                {
                    Skill_Extended skill_Extended = PlayData.GetBattleEnforce(skill).Random(this.BChar.GetRandomClass().Main);
                    if (skill_Extended != null)
                    {
                        skill.ExtendedAdd_Battle(skill_Extended);
                        skill.MyButton.InputData(skill, null, false);
                    }
                }
            }

            yield return null;
            yield break;
        }
    }
}