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
namespace HiHouClab
{
	/// <summary>
	/// 宇佐见莲子
	/// Passive:
	/// 宇佐见莲子无法通过常规手段暴击。获得的暴击率全部转化为暴击伤害。
	/// 技能对行动倒计时1的敌人必定暴击。
	/// 此外，每次使用宇佐见莲子的非迅速技能后，立即打出迅速技能时，会恢复 1 点法力值，并使宇佐见莲子获得“专注模式”增益：下 1 个非迅速的攻击技能造成等量于攻击力的100%的额外伤害。
	/// </summary>
    public class P_UsamiRenko:Passive_Char, IP_DamageChange, IP_SkillUseHand_Team
    {
        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
        }

        public int DamageChange(Skill SkillD, BattleChar Target, int Damage, ref bool Cri, bool View)
        {
            Cri = false;

            if (Target is BattleEnemy)
            {
                BattleEnemy battleEnemy = Target as BattleEnemy;
                if (battleEnemy.SkillQueue.Count != 0 && battleEnemy.SkillQueue[0].CastSpeed == 1)
                {
                    Cri = true;
                }
            }

            return Damage;
        }

        public void SKillUseHand_Team(Skill skill)
        {
            if (!skill.NotCount && skill.Master == this.BChar)
            {
                this.BChar.BuffAdd("B_Renko_P", this.BChar);
            }
        }
    }
}