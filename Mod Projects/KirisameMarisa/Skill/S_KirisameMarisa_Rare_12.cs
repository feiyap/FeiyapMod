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
using ChronoArkMod.ModData;
using ChronoArkMod.Plugin;
using ChronoArkMod.Template;
using Debug = UnityEngine.Debug;
namespace KirisameMarisa
{
	/// <summary>
	/// 星符「Satellite Illusion」
	/// 抽取1个技能。
	/// <i><color=#696969>似乎能和其他稀有符卡共鸣，引发出更加独特的力量……</color></i>
	/// </summary>
    public class S_KirisameMarisa_Rare_12:Skill_Extended
    {
        public bool flag;

        public override void Init()
        {
            base.Init();
            flag = false;
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            
            if (!this.flag && this.MySkill.MyButton != null && !this.MySkill.BasicSkill && !this.MySkill.MyButton.AlreadyWasted)
            {
                bool flag = false;
                int num = -9;
                for (int i = 0; i < BattleSystem.instance.AllyTeam.Skills.Count; i++)
                {
                    if (BattleSystem.instance.AllyTeam.Skills[i] == this.MySkill)
                    {
                        num = i;
                    }
                }
                int mynum = -9;
                for (int j = 0; j < BattleSystem.instance.AllyTeam.Skills.Count; j++)
                {
                    if (BattleSystem.instance.AllyTeam.Skills[j].MySkill.KeyID == "S_HakureiReimu_F_10Rare" && (j == num - 1 || j == num + 1))
                    {
                        mynum = j;
                        flag = true;
                        break;
                    }
                }
                if (flag)
                {
                    this.flag = true;
                    BattleSystem.DelayInput(this.Effect(num, mynum));
                }
            }
        }

        public IEnumerator Effect(int Mynum, int Mynum2)
        {
            yield return new WaitForSecondsRealtime(0.2f);
            Skill skill;
            Skill skill2;
            if (Mynum < BattleSystem.instance.AllyTeam.Skills.Count && Mynum2 < BattleSystem.instance.AllyTeam.Skills.Count)
            {
                skill = BattleSystem.instance.AllyTeam.Skills[Mynum];
                skill2 = BattleSystem.instance.AllyTeam.Skills[Mynum2];
                if (skill.MyButton != null && !skill.MyButton.AlreadyWasted && skill2.MyButton != null && !skill2.MyButton.AlreadyWasted)
                {
                    skill.Delete(false);
                    skill2.Delete(false);
                }

                BattleSystem.instance.AllyTeam.Skills.Add(Skill.TempSkill("S_Satellite_Reimu", BattleSystem.instance.AllyTeam.LucyChar, BattleSystem.instance.AllyTeam));

                BattleSystem.instance.StartCoroutine(BattleSystem.instance.ActWindow.Window.SkillInstantiate(BattleSystem.instance.AllyTeam, true));
            }

            yield return new WaitForFixedUpdate();
            yield break;
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            BattleSystem.instance.AllyTeam.Draw();
        }
    }
}