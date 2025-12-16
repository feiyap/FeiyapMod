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
namespace Jhin
{
	/// <summary>
	/// 完美谢幕 - 入场曲
	/// 生成“完美谢幕 - 渐起曲”。
	/// 目标每损失1%体力值，这个技能的伤害提升1%。
	/// 对处于“无法行动”的敌人造成的伤害翻倍。
	/// </summary>
    public class S_Jhin_Rare_1_1:Skill_Extended, IP_DamageChange_sumoperation
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            Skill tmpSkill = Skill.TempSkill("S_Jhin_Rare_1_2", this.BChar, this.BChar.MyTeam);
            tmpSkill.isExcept = true;
            tmpSkill.AutoDelete = 1;
            BattleSystem.instance.AllyTeam.Add(tmpSkill, true);

            if (SkillD.Master.Info.KeyData == "Jhin")
            {
                MasterAudio.PlaySound("SE_Jhin_Rare_1_1", 1f, null, 0f, null, null, false, false);
            }
        }

        public void DamageChange_sumoperation(Skill SkillD, BattleChar Target, int Damage, ref bool Cri, bool View, ref int PlusDamage)
        {
            int num = 0;

            num = (int)((float)(Target.GetStat.maxhp - Target.HP) * 100 / Target.GetStat.maxhp);

            if (Target.GetStat.Stun)
            {
                num *= 2;
                num += 100;
            }

            if (num > 0)
            {
                PlusDamage = BattleChar.CalculationResult((float)Damage, num, 0);
            }
        }
    }
}