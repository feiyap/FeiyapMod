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
namespace Yuyuko
{
	/// <summary>
	/// 蝶符「凤蝶纹的死枪」
	/// 目标每损失1点最大体力值，这个技能的伤害提升1%。
	/// 葬送 - 对随机敌人释放这个技能。
	/// 幽冥蝶 - 回引时，造成&a的伤害(&user攻击力的90%)。
	/// 人魂蝶 - 回引时，(100%干扰成功率)眩晕1回合。
	/// </summary>
    public class S_YuyukoF_5:Skill_Extended, IP_DamageChange_sumoperation, IP_SkillSelfExcept
    {
        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
        }

        public void DamageChange_sumoperation(Skill SkillD, BattleChar Target, int Damage, ref bool Cri, bool View, ref int PlusDamage)
        {
            int num = BattleSystem.instance.GetBattleValue<BV_YuyukoF_P>().dieList[Target];
            if (num > 0)
            {
                PlusDamage = BattleChar.CalculationResult((float)Damage, num, 0);
            }
        }

        public bool SelfExcept(SkillLocation skillLoaction)
        {
            BattleSystem.DelayInput(BattleSystem.instance.SkillRandomUseIenum(this.BChar, this.MySkill, false, true, false));
            return true;
        }
    }
}