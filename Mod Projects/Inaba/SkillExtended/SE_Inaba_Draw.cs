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
namespace Inaba
{
	/// <summary>
	/// <color=#FFD700>帝的豪华奖池</color>
	/// </summary>
    public class SE_Inaba_Draw:Skill_Extended
    {
        public void InabaDraw(int count = 1, bool isLucyD = false)
        {
            BattleChar usingChar = this.BChar;
            if (isLucyD)
            {
                using (List<BattleChar>.Enumerator enumerator = BattleSystem.instance.AllyTeam.AliveChars.GetEnumerator())
                {
                    while (enumerator.MoveNext())
                    {
                        if (enumerator.Current.Info.KeyData == "Inaba")
                        {
                            usingChar = enumerator.Current;
                            break;
                        }
                    }
                }
            }

            for (int i = 0; i < count; i++)
            {
                int ran = RandomManager.RandomInt(usingChar.GetRandomClass().Main, 1, 32);
                if (ran == 31)
                {
                    Skill skill = Skill.TempSkill("S_Inaba_P_6", usingChar, usingChar.MyTeam);
                    skill.PlusHit = true;
                    BattleSystem.DelayInput(this.InabaAttack(skill, BattleSystem.instance.AllyList.Random(usingChar.GetRandomClass().Main)));
                }
                else if (ran >= 25)
                {
                    Skill skill = Skill.TempSkill("S_Inaba_P_5", usingChar, usingChar.MyTeam);
                    skill.PlusHit = true;
                    BattleSystem.DelayInput(this.InabaAttack(skill, BattleSystem.instance.EnemyList.Random(usingChar.GetRandomClass().Main)));
                }
                else if (ran >= 20)
                {
                    Skill skill = Skill.TempSkill("S_Inaba_P_4", usingChar, usingChar.MyTeam);
                    skill.PlusHit = true;
                    BattleSystem.DelayInput(this.InabaAttack(skill, BattleSystem.instance.EnemyList.Random(usingChar.GetRandomClass().Main)));
                }
                else if (ran >= 15)
                {
                    Skill skill = Skill.TempSkill("S_Inaba_P_3", usingChar, usingChar.MyTeam);
                    skill.PlusHit = true;
                    BattleSystem.DelayInput(this.InabaAttack(skill, BattleSystem.instance.EnemyList.Random(usingChar.GetRandomClass().Main)));
                }
                else if (ran >= 10)
                {
                    Skill skill = Skill.TempSkill("S_Inaba_P_2", usingChar, usingChar.MyTeam);
                    skill.PlusHit = true;
                    BattleSystem.DelayInput(this.InabaAttack(skill, BattleSystem.instance.EnemyList.Random(usingChar.GetRandomClass().Main)));
                }
                else if (ran >= 5)
                {
                    Skill skill = Skill.TempSkill("S_Inaba_P_1", usingChar, usingChar.MyTeam);
                    skill.PlusHit = true;
                    BattleSystem.DelayInput(this.InabaAttack(skill, BattleSystem.instance.AllyList.Random(usingChar.GetRandomClass().Main)));
                }
                else
                {
                    Skill skill = Skill.TempSkill("S_Inaba_P_0", usingChar, usingChar.MyTeam);
                    skill.PlusHit = true;
                    BattleSystem.DelayInput(this.InabaAttack(skill, BattleSystem.instance.EnemyList.Random(usingChar.GetRandomClass().Main)));
                }
            }
        }

        public IEnumerator InabaAttack(Skill AttackSkill, BattleChar Target)
        {
            yield return new WaitForSeconds(0.2f);
            if (!Target.IsDead)
            {
                yield return BattleSystem.instance.ForceAction(AttackSkill, Target, false, false, true, null);
            }
            else if (Target.Info.Ally)
            {
                yield return BattleSystem.instance.ForceAction(AttackSkill, BattleSystem.instance.AllyList.Random(this.BChar.GetRandomClass().Main), false, false, true, null);
            }
            else
            {
                yield return BattleSystem.instance.ForceAction(AttackSkill, BattleSystem.instance.EnemyList.Random(this.BChar.GetRandomClass().Main), false, false, true, null);
            }
            yield break;
        }
    }
}