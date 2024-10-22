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
namespace ShameimaruAya
{
	/// <summary>
	/// 风来的幻想
	/// </summary>
    public class B_Shameimaru_Rare10:Buff
    {
        public bool flag1;
        public bool flag2;
        public bool flag3;
        public bool flag4;
        public bool flag5;

        public override void Init()
        {
            base.Init();
            flag1 = false;
            flag2 = false;
            flag3 = false;
            flag4 = false;
            flag5 = false;
        }

        public int fixCount = 0;

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            if (fixCount >= 12)
            {
                fixCount = 0;

                if (CheckUsedSkills(4) && !flag1)
                {
                    flag1 = true;
                    BattleSystem.instance.AllyTeam.AP += 2;
                }

                if (CheckUsedSkills(8) && !flag2)
                {
                    flag2 = true;
                    this.BChar.BuffAdd("B_Shameimaru_Rare10_0", this.BChar);
                }

                if (CheckUsedSkills(12) && !flag3)
                {
                    flag3 = true;
                    for (int i = 0; i < 2; i++)
                    {
                        BattleSystem.instance.AllyTeam.CharacterDraw(this.BChar, null);
                    }
                }

                if (CheckUsedSkills(16) && !flag4)
                {
                    flag4 = true;
                    foreach (Skill skill in BattleSystem.instance.AllyTeam.Skills)
                    {
                        Extended_Lucy_3_1 extended = new Extended_Lucy_3_1();
                        skill.ExtendedAdd(extended);
                    }
                }

                if (CheckUsedSkills(20) && !flag5)
                {
                    flag5 = true;
                    BattleSystem.DelayInputAfter(this.Ienum());
                }
            }
        }

        public IEnumerator Ienum()
        {
            yield return new WaitForSecondsRealtime(0.1f);
            Skill skill = Skill.TempSkill("S_Shameimaru_Rare10_0", this.BChar, this.BChar.MyTeam);
            skill.PlusHit = true;
            skill.isExcept = true;
            skill.FreeUse = true;

            this.BChar.ParticleOut(skill, this.BChar.BattleInfo.EnemyList.Random(this.BChar.GetRandomClass().Main));

            yield break;
        }

        public bool CheckUsedSkills(int count)
        {
            return BattleSystem.instance.BattleLogs.getSkills((BattleLog log) => log.WhoUse.Info.Ally, (Skill skill) => !skill.FreeUse, BattleSystem.instance.TurnNum).Count == count;
        }

        public override string DescExtended()
        {
            if (BattleSystem.instance == null)
            {
                return base.DescExtended().Replace("&a", ((int)(this.BChar.GetStat.atk * 3)).ToString()).Replace("&b", (0).ToString());
            }
            return base.DescExtended().Replace("&a", ((int)(this.BChar.GetStat.atk * 3)).ToString()).Replace("&b", ((int)(BattleSystem.instance.BattleLogs.getSkills((BattleLog log) => log.WhoUse.Info.Ally, (Skill skill) => !skill.FreeUse, BattleSystem.instance.TurnNum).Count)).ToString());
        }
    }
}