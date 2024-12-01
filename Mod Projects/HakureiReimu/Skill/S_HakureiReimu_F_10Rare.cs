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
namespace HakureiReimu
{
	/// <summary>
	/// 「梦想天生」
	/// 抽取1个技能。
	/// <i><color=#696969>似乎能和其他稀有符卡共鸣，引发出更加独特的力量……</color></i>
	/// </summary>
    public class S_HakureiReimu_F_10Rare: SkillExtended_Reimu
    {
        public bool flag;

        public override void Init()
        {
            base.Init();
            flag = false;
        }

        public override void FixedUpdate()
        {
            if (!flag && this.MySkill.MyButton != null && !this.MySkill.BasicSkill && !this.MySkill.MyButton.AlreadyWasted)
            {
                int num = -9;
                for (int i = 0; i < BattleSystem.instance.AllyTeam.Skills.Count; i++)
                {
                    if (BattleSystem.instance.AllyTeam.Skills[i] == this.MySkill)
                    {
                        num = i;
                    }
                }
                for (int j = 0; j < BattleSystem.instance.AllyTeam.Skills.Count; j++)
                {
                    if (checkReimuFusion(BattleSystem.instance.AllyTeam.Skills[j], num, j))
                    {
                        flag = true;
                        break;
                    }
                }
            }
        }

        public bool checkReimuFusion(Skill skill, int num, int j)
        {
            if (!(j == num - 1 || j == num + 1))
            {
                return false;
            }
            for (int i = 0;i < FusionCard.Count; i++)
            {
                if (skill.MySkill.KeyID == FusionCard[i])
                {
                    BattleSystem.DelayInput(this.Effect(i));
                    return true;
                }
            }
            return false;
        }

        public IEnumerator Effect(int num)
        {
            yield return new WaitForSecondsRealtime(0.2f);
            
            BattleSystem.DelayInputAfter(this.Del(num));

            yield return new WaitForFixedUpdate();
            yield break;
        }

        public IEnumerator Del(int num)
        {
            yield return new WaitForFixedUpdate();
            
            yield return this.TalkEnd(num);

            yield break;
        }

        public IEnumerator TalkEnd(int num)
        {
            yield return new WaitForFixedUpdate();
            
            yield return BattleText.InstBattleTextAlly_Co(this.BChar, ModManager.getModInfo("HakureiReimu").localizationInfo.SystemLocalizationUpdate("BattleDia/Musoutensei/Text2"), false);

            SkillChange(FusionCard[num + 1]);

            yield break;
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            BattleSystem.instance.AllyTeam.Draw();
        }

        public List<string> FusionCard = new List<string>
        {
            "S_RemiliaScarlet_2",
            "S_Musoutensei_Remilia",
            "S_Sakuya_10Rare",
            "S_Musoutensei_Sakuya",
            "S_Satsuki_11Rare",
            "S_Musoutensei_Satsuki",
            "S_FlandreScarlet_12Rare",
            "S_Musoutensei_Flandre",
            "S_Reisen_10Rare",
            "S_Musoutensei_Reisen",
            "S_Eirin_11Rare",
            "S_Musoutensei_Eirin",
            "S_FKaguya_12Rare",
            "S_Musoutensei_Kaguya",
            "S_Inaba_Rare10",
            "S_Musoutensei_Inaba",
            "S_Mokou_R_1",
            "S_Musoutensei_Mokou",
            "S_Touhoualice_R1",
            "S_Musoutensei_Alice",
            "S_Utuho_11",
            "S_Musoutensei_Utuho",
            "S_LilyWhite_Spring_Rare_2",
            "S_Musoutensei_Lilywhite"
        };
    }
}