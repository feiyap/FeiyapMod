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
namespace IzayoiSakuya
{
	/// <summary>
	/// 幻葬「夜雾幻影杀人鬼」
	/// 每有1层[时钟停摆]，额外造成%a伤害。
	/// </summary>
    public class S_Sakuya_11Rare:Skill_Extended
    {
        public override void Init()
        {
            base.Init();
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            int count = BattleSystem.instance.GetBattleValue<BV_Sakuya_TKnife>().KnifeList[this.BChar];

            if (count >= 1)
            {
                foreach (BattleChar bc in Targets)
                {
                    Skill skill = Skill.TempSkill("S_Sakuya_Knife", this.BChar, this.BChar.MyTeam);
                    skill.isExcept = true;
                    skill.FreeUse = true;
                    skill.PlusHit = true;

                    if (bc != null || bc.IsDead)
                    {
                        for (int i = 0; i<count;i++)
                        {
                            BattleSystem.DelayInputAfter(this.Attack(bc));
                        }
                    }
                }
            }

            BattleSystem.instance.GetBattleValue<BV_Sakuya_TKnife>().KnifeList[this.BChar] = 0;
        }

        public IEnumerator Attack(BattleChar bc)
        {
            yield return new WaitForSecondsRealtime(0.1f);

            Skill skill = Skill.TempSkill("S_Sakuya_Knife", this.BChar, this.BChar.MyTeam);
            skill.isExcept = true;
            skill.FreeUse = true;
            skill.PlusHit = true;

            if (bc != null || bc.IsDead)
            {
                this.BChar.ParticleOut(skill, bc);
            }

            yield break;
        }

        public override string DescExtended(string desc)
        {
            return base.DescExtended(desc).Replace("&a", ((int)(this.BChar.GetStat.atk * 0.3f)).ToString());
        }
    }
}