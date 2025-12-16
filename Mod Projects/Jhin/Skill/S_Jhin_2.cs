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
	/// 致命华彩
	/// 对本回合内受到过伤害的敌人释放时，施加(144%<sprite=2>)眩晕。
	/// 对处于“无法行动”的敌人释放时，造成 4 倍伤害。
	/// </summary>
    public class S_Jhin_2:Skill_Extended, IP_DamageChange_sumoperation, IP_DamageChange
    {
        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();

            foreach (BattleEnemy be in BattleSystem.instance.EnemyList)
            {
                if (be.BuffFind("B_Jhin_2"))
                {
                    be.BuffReturn("B_Jhin_2").BuffIcon.SetActive(true);
                }
            }
        }

        public void DamageChange_sumoperation(Skill SkillD, BattleChar Target, int Damage, ref bool Cri, bool View, ref int PlusDamage)
        {
            if (Target.GetStat.Stun)
            {
                PlusDamage = BattleChar.CalculationResult((float)Damage, 300, 0);
            }
        }


        public int DamageChange(Skill SkillD, BattleChar Target, int Damage, ref bool Cri, bool View)
        {
            if (Target.BuffFind("B_Jhin_2") && !View)
            {
                Target.BuffAdd(GDEItemKeys.Buff_B_Common_Rest, this.BChar, false, 144, false, -1, false);
            }

            return Damage;
        }
    }
}