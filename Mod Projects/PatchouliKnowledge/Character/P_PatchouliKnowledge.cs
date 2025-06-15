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
namespace PatchouliKnowledge
{
	/// <summary>
	/// 帕秋莉
	/// Passive:
	/// <b>知识与避世的少女</b> - 战斗开始时，在本次战斗期间放逐自己的所有“元素”技能。每个被放逐的“元素”技能会转化为“元素”属性，重复转化的“元素”属性会提升属性的等级。
	/// <b>使用魔法程度的能力</b> - <b>固定能力替换为“元素祈唤”。</b>
	/// 等级到达3级时，每个回合第 1 次释放“元素祈唤”后，重置“元素祈唤”的冷却时间。
	/// 等级到达5级时，“元素祈唤”不再拥有冷却时间。
	/// <color=#919191>- 此被动从1级开始生效。</color>
	/// <color=#919191>- 帕秋莉的技能学习不再拥有上限。</color>
	/// </summary>
    public class P_PatchouliKnowledge:Passive_Char, IP_BattleStart_Ones, IP_OnSkillExcept, IP_PlayerTurn
    {
        public static List<string> BaseElement = new List<string>
        {
            "S_Pachi_E_0",
            "S_Pachi_E_1",
            "S_Pachi_E_2",
            "S_Pachi_E_3",
            "S_Pachi_E_4"
        };

        public static List<string> RareElement = new List<string>
        {
            "S_Pachi_E_5",
            "S_Pachi_E_6"
        };

        public static Skill firstskill = new Skill();
        public static Skill secondskill = new Skill();

        public static Dictionary<(int, int), string> GenerateSkillMap()
        {
            var skillMap = new Dictionary<(int, int), string>();

            for (int e1 = 0; e1 < 7; e1++)
            {
                for (int e2 = 0; e2 < 7; e2++)
                {
                    int code1 = Math.Min((int)e1, (int)e2);
                    int code2 = Math.Max((int)e1, (int)e2);

                    // 技能命名规则：S_Patchouli_Sk_X_Y
                    string skillName = $"S_Pachi_Sk_{code1}_{code2}";

                    // 存入字典（注意可以决定是否要区分顺序）
                    skillMap[(e1, e2)] = skillName;
                }
            }

            return skillMap;
        }

        public static string GetSkill(Skill s1, Skill s2)
        {
            var skillMap = GenerateSkillMap();

            int e1 = int.Parse(s1.MySkill.KeyID.Split('_').Last());
            int e2 = int.Parse(s2.MySkill.KeyID.Split('_').Last());

            if (e1 == 5)
            {
                BattleSystem.instance.GetBattleValue<BV_Pachi_P>().setSunUsed(e2);
            }
            if (e1 == 6)
            {
                BattleSystem.instance.GetBattleValue<BV_Pachi_P>().setMoonUsed(e2);
            }
            if (e2 == 5)
            {
                BattleSystem.instance.GetBattleValue<BV_Pachi_P>().setSunUsed(e1);
            }
            if (e2 == 6)
            {
                BattleSystem.instance.GetBattleValue<BV_Pachi_P>().setMoonUsed(e1);
            }

            // 你可以选择是否支持不区分顺序（比如 e1,e2 和 e2,e1 是同一个技能）
            if (skillMap.TryGetValue((e1, e2), out var skill))
                return skill;

            return null;
        }

        //OP领域大神
        public override void Init()
        {
            base.Init();
            this.OnePassive = true;

            firstskill = null;
            secondskill = null;
        }

        //战斗开始时，放逐所有元素技能
        public void BattleStart(BattleSystem Ins)
        {
            if (BattleSystem.instance.GetBattleValue<BV_Pachi_P>() == null)
            {
                BattleSystem.instance.BattleValues.Add(new BV_Pachi_P());
            }
            
            this.BChar.BuffAdd("B_Pachi_P", this.BChar);

            firstskill = null;
            secondskill = null;

            List<Skill> AList = BattleSystem.instance.AllyTeam.Skills_Deck
                        .Where(skill => skill.Master == this.BChar && (BaseElement.Contains(skill.MySkill.KeyID) || RareElement.Contains(skill.MySkill.KeyID)))
                        .ToList();

            foreach (Skill sk in AList)
            {
                //BattleSystem.instance.AllyTeam.Draw(sk, new BattleTeam.DrawInput(this.DrawInput));
                BattleSystem.instance.AllyTeam.Skills_Deck.Remove(sk);
                BV_ExceptDeck.AddSkill(sk);
            }
        }

        //public void Turn1()
        //{
        //    if (BattleSystem.instance.TurnNum == 1)
        //    {
        //        List<Skill> AList = BattleSystem.instance.AllyTeam.Skills_Deck
        //                .Where(skill => skill.Master == this.BChar && (BaseElement.Contains(skill.MySkill.KeyID) || RareElement.Contains(skill.MySkill.KeyID)))
        //                .ToList();

        //        foreach (Skill sk in AList)
        //        {
        //            BattleSystem.instance.AllyTeam.Draw(sk, new BattleTeam.DrawInput(this.DrawInput));
        //        }

        //        List<Skill> BList = BattleSystem.instance.AllyTeam.Skills
        //                    .Where(skill => skill.Master == this.BChar && (BaseElement.Contains(skill.MySkill.KeyID) || RareElement.Contains(skill.MySkill.KeyID)))
        //                    .ToList();

        //        foreach (Skill sk in BList)
        //        {
        //            sk.Except();
        //            BattleSystem.instance.AllyTeam.Draw();
        //            BV_ExceptDeck.AddSkill(sk);
        //        }
        //    }
        //}

        //public void FirstDrawBefore(List<Skill> Skills_Deck)
        //{
        //    BattleSystem.instance.ActWindow.On = true;

        //    List<Skill> AList = BattleSystem.instance.AllyTeam.Skills_Deck
        //            .Where(skill => skill.Master == this.BChar && (BaseElement.Contains(skill.MySkill.KeyID) || RareElement.Contains(skill.MySkill.KeyID)))
        //            .ToList();

        //    foreach (Skill sk in AList)
        //    {
        //        BattleSystem.instance.AllyTeam.Draw(sk, new BattleTeam.DrawInput(this.DrawInput));
        //    }
        //}

        public void DrawInput(Skill skill)
        {
            skill.Except();
            BV_ExceptDeck.AddSkill(skill);
        }

        //元素技能被放逐时，提升对应元素等级
        public bool OnSkillExcept(Dictionary<Skill, SkillLocation> exceptSkills)
        {
            if (BattleSystem.instance.GetBattleValue<BV_Pachi_P>() == null)
            {
                BattleSystem.instance.BattleValues.Add(new BV_Pachi_P());
            }

            foreach (KeyValuePair<Skill, SkillLocation> entry in exceptSkills)
            {
                Skill skill = entry.Key;
                SkillLocation location = entry.Value;

                if (BaseElement.Contains(skill.MySkill.KeyID) || RareElement.Contains(skill.MySkill.KeyID))
                {
                    int index = int.Parse(skill.MySkill.KeyID.Split('_').Last());
                    BattleSystem.instance.GetBattleValue<BV_Pachi_P>().setElementLevel(index, 1);
                }
            }

            return true;
        }

        //等级到达3级时，每个回合第 1 次释放“元素祈唤”后，重置“元素祈唤”的冷却时间。
        public void Turn()
        {
            this.BChar.MyTeam.BasicSkillRefill(this.BChar, this.BChar.BattleBasicskillRefill);

            if (this.BChar.Info.LV >= 3)
            {
                this.BChar.BuffAdd("B_Pachi_P_1", this.BChar);
            }

            if (this.BChar.Info.LV >= 5)
            {
                this.BChar.BuffAdd("B_Pachi_P_1", this.BChar);
            }
        }

        //检测日是否可用
        public static bool isSunCanUsed()
        {
            List<int> activeElements = new List<int>();

            for (int i = 0; i < 5; i++)
            {
                if (BattleSystem.instance.GetBattleValue<BV_Pachi_P>().elementLevel[i] != 0 && i < P_PatchouliKnowledge.BaseElement.Count)
                {
                    activeElements.Add(i);
                }
            }

            for (int i = 5; i < BattleSystem.instance.GetBattleValue<BV_Pachi_P>().elementLevel.Count; i++)
            {
                int rareIndex = i - 5; // 转换为稀有元素列表的索引
                if (BattleSystem.instance.GetBattleValue<BV_Pachi_P>().elementLevel[i] != 0 && rareIndex < P_PatchouliKnowledge.RareElement.Count)
                {
                    activeElements.Add(i);
                }
            }

            foreach (int count in activeElements)
            {
                if (BattleSystem.instance.GetBattleValue<BV_Pachi_P>().sunUsed[count] == 0)
                {
                    return true;
                }
            }

            return false;
        }

        //检测月是否可用
        public static bool isMoonCanUsed()
        {
            List<int> activeElements = new List<int>();

            for (int i = 0; i < 5; i++)
            {
                if (BattleSystem.instance.GetBattleValue<BV_Pachi_P>().elementLevel[i] != 0 && i < P_PatchouliKnowledge.BaseElement.Count)
                {
                    activeElements.Add(i);
                }
            }

            for (int i = 5; i < BattleSystem.instance.GetBattleValue<BV_Pachi_P>().elementLevel.Count; i++)
            {
                int rareIndex = i - 5; // 转换为稀有元素列表的索引
                if (BattleSystem.instance.GetBattleValue<BV_Pachi_P>().elementLevel[i] != 0 && rareIndex < P_PatchouliKnowledge.RareElement.Count)
                {
                    activeElements.Add(i);
                }
            }

            foreach (int count in activeElements)
            {
                if (BattleSystem.instance.GetBattleValue<BV_Pachi_P>().moonUsed[count] == 0)
                {
                    return true;
                }
            }

            return false;
        }
    }
}