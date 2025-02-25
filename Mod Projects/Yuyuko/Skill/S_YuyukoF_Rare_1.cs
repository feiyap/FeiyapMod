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
using System.Text;
using BasicMethods;
namespace Yuyuko
{
	/// <summary>
	/// 「反魂蝶」
	/// 握在手中时，自身每次进入永眠状态时，使这个技能获得：打出时，重复释放1次。
	/// 这个技能最多能重复释放10次。
	/// 葬送 - 将这个技能拿回手中，并使这个技能获得：打出时，重复释放1次。
	/// 幽冥蝶 - 
	/// 人魂蝶 - 
	/// </summary>
    public class S_YuyukoF_Rare_1:Skill_Extended, IP_BuffAddAfter, IP_SkillSelfExcept
    {
        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
            this.SkillParticleObject = new GDESkillExtendedData(GDEItemKeys.SkillExtended_Public_1_Ex).Particle_Path;
        }

        public int Fixed_count = 0;

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            Fixed_count++;

            if (Fixed_count >= 12)
            {
                Fixed_count = 0;

                if (Num >= 9)
                {
                    Num = 9;
                    GDESkillData gdeskillData = new GDESkillData("S_YuyukoF_Rare_1_0");
                    this.MySkill.Image_Skill = gdeskillData.Image_0_Path;
                    this.MySkill.Image_Button = gdeskillData.Image_1_Path;
                    this.MySkill.Image_Basic = gdeskillData.Image_2_Path;
                    base.SkillParticleOn();
                }
                else
                {
                    GDESkillData gdeskillData = new GDESkillData("S_YuyukoF_Rare_1");
                    this.MySkill.Image_Skill = gdeskillData.Image_0_Path;
                    this.MySkill.Image_Button = gdeskillData.Image_1_Path;
                    this.MySkill.Image_Basic = gdeskillData.Image_2_Path;
                    base.SkillParticleOff();
                }

                this.MySkill.MySkill.Name = ModManager.getModInfo("Yuyuko").localizationInfo.SystemLocalizationUpdate("S_YuyukoF_Rare_1") + ConvertToChinese(this.Num + 1) + ModManager.getModInfo("Yuyuko").localizationInfo.SystemLocalizationUpdate("S_YuyukoF_Rare_1_0");
                this.MySkill.MyButton.InputData(this.MySkill, null, false);
            }
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);
            for (int i = 0; i < this.Num; i++)
            {
                BattleSystem.DelayInput(this.Damage(Targets[0]));
            }
            this.Num = 0;
        }

        public IEnumerator Damage(BattleChar Target)
        {
            if (this.BChar.BattleInfo.EnemyList.Count != 0)
            {
                yield return new WaitForSecondsRealtime(0.3f);
                Skill skill = Skill.TempSkill("S_YuyukoF_Rare_1_0", this.BChar, this.BChar.MyTeam);
                Skill_Extended skill_Extended = new Skill_Extended();
                skill.FreeUse = true;
                skill.PlusHit = true;
                skill.ExtendedAdd(skill_Extended);
                if (this.MySkill.AllExtendeds.Count > 0)
                {
                    foreach (Skill_Extended extended in this.MySkill.AllExtendeds)
                    {
                        skill.ExtendedAdd(extended);
                    }
                }
                if (Target.IsDead)
                {
                    this.BChar.ParticleOut(this.MySkill, skill, this.BChar.BattleInfo.EnemyList.Random(this.BChar.GetRandomClass().Main));
                }
                else
                {
                    this.BChar.ParticleOut(this.MySkill, skill, Target);
                }
            }
            yield break;
        }

        public void BuffaddedAfter(BattleChar BuffUser, BattleChar BuffTaker, Buff addedbuff, StackBuff stackBuff)
        {
            if (BuffTaker == this.BChar && addedbuff.BuffData.Key == "B_YuyukoF_P_3")
            {
                BattleSystem.DelayInput(this.Draw());
            }
        }

        public bool SelfExcept(SkillLocation skillLoaction)
        {
            BattleSystem.DelayInput(this.Draw());
            return true;
        }

        public IEnumerator Draw()
        {
            Skill targetskill = BV_ExceptDeck.TryGetExcptedSkills().Find((Skill a) => a.CharinfoSkilldata == this.MySkill.CharinfoSkilldata);
            if (BattleSystem.instance.AllyTeam.Skills.Find((Skill a) => a.CharinfoSkilldata == this.MySkill.CharinfoSkilldata) == null
                && !this.MySkill.Master.IsDead)
            {
                BV_ExceptDeck.RemoveSkill(targetskill);
                BattleSystem.instance.AllyTeam.Add(targetskill, false);
            }

            BattleSystem.DelayInputAfter(this.AlreadyHand());

            yield return null;
            yield break;
        }

        public IEnumerator AlreadyHand()
        {
            yield return new WaitForFixedUpdate();
            this.DrawInput(BattleSystem.instance.AllyTeam.Skills.Find((Skill a) => a.CharinfoSkilldata == this.MySkill.CharinfoSkilldata));
            yield break;
        }

        public void DrawInput(Skill skill)
        {
            if (skill == null)
            {
                return;
            }
            foreach (Skill_Extended skill_Extended in skill.AllExtendeds)
            {
                if (skill_Extended is S_YuyukoF_Rare_1)
                {
                    if ((skill_Extended as S_YuyukoF_Rare_1).Num == this.Num + 1)
                    {
                        (skill_Extended as S_YuyukoF_Rare_1).Num++;
                        if ((skill_Extended as S_YuyukoF_Rare_1).Num >= 9)
                        {
                            (skill_Extended as S_YuyukoF_Rare_1).Num = 9;
                        }
                    }
                    else
                    {
                        (skill_Extended as S_YuyukoF_Rare_1).Num = this.Num + 1;
                    }

                    skill.MyButton.InputData(skill, null, false);
                }
            }
        }

        public string NumToString(int num)
        {
            // 定义数字到中文字符的映射
            string[] chineseNumbers = { "零", "一", "二", "三", "四", "五", "六", "七", "八", "九", "十" };

            // 将数字转换为字符串
            string numStr = num.ToString();
            string result = "";

            // 遍历每个字符并映射到对应的中文字符
            foreach (char c in numStr)
            {
                int digit = c - '0'; // 将字符转换为数字
                result += chineseNumbers[digit];
            }

            return result;
        }
        
        private static readonly string[] ChineseDigits = { "零", "一", "二", "三", "四", "五", "六", "七", "八", "九" };
        private static readonly string[] ChineseUnits = { "", "万", "亿", "兆" }; // 可根据需要扩展更高单位

        public static string ConvertToChinese(long number)
        {
            if (number == 0)
                return ChineseDigits[0];

            bool isNegative = false;
            if (number < 0)
            {
                isNegative = true;
                number = -number;
            }

            List<int> sections = new List<int>();
            while (number > 0)
            {
                sections.Add((int)(number % 10000));
                number /= 10000;
            }
            sections.Reverse();

            StringBuilder result = new StringBuilder();
            int lastUnitIndex = -1;

            for (int i = 0; i < sections.Count; i++)
            {
                int section = sections[i];
                if (section == 0)
                    continue;

                string sectionStr = ConvertSection(section);
                int currentUnitIndex = sections.Count - 1 - i;
                sectionStr += ChineseUnits[currentUnitIndex];

                if (lastUnitIndex != -1 && lastUnitIndex > currentUnitIndex + 1)
                {
                    result.Append(ChineseDigits[0]); // 添加零
                }

                result.Append(sectionStr);
                lastUnitIndex = currentUnitIndex;
            }

            if (isNegative)
            {
                result.Insert(0, "负");
            }

            return result.ToString();
        }

        private static string ConvertSection(int section)
        {
            if (section < 0 || section >= 10000)
                throw new ArgumentOutOfRangeException(nameof(section), "Section must be between 0 and 9999.");

            if (section == 0)
                return ChineseDigits[0];

            int d3 = section / 1000;
            int d2 = (section % 1000) / 100;
            int d1 = (section % 100) / 10;
            int d0 = section % 10;

            List<Tuple<int, string>> parts = new List<Tuple<int, string>>();

            if (d3 != 0)
                parts.Add(Tuple.Create(3, $"{ChineseDigits[d3]}千"));
            if (d2 != 0)
                parts.Add(Tuple.Create(2, $"{ChineseDigits[d2]}百"));
            if (d1 != 0)
                parts.Add(Tuple.Create(1, $"{ChineseDigits[d1]}十"));
            if (d0 != 0)
                parts.Add(Tuple.Create(0, ChineseDigits[d0]));

            if (parts.Count == 0)
                return ChineseDigits[0];

            parts.Sort((a, b) => b.Item1.CompareTo(a.Item1));

            StringBuilder sb = new StringBuilder();
            int previousPosition = parts[0].Item1;
            sb.Append(parts[0].Item2);

            for (int i = 1; i < parts.Count; i++)
            {
                int currentPosition = parts[i].Item1;
                if (previousPosition - currentPosition > 1)
                {
                    sb.Append(ChineseDigits[0]);
                }
                sb.Append(parts[i].Item2);
                previousPosition = currentPosition;
            }

            string sectionStr = sb.ToString();
            // 处理十位为1的情况（例如：10 -> 十，而不是一十）
            if (sectionStr.StartsWith("一十"))
            {
                sectionStr = sectionStr.Substring(1);
            }

            return sectionStr;
        }

        public int Num;
    }
}