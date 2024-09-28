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
	/// 封魔针
	/// 每个回合第一次攻击命中时，随机使敌人攻击力、防御力、命中率、减益成功率中的一项在3回合内降低15%。
	/// </summary>
    public class E_HakureiReimu_F_1:EquipBase, IP_SkillUse_Target, IP_PlayerTurn
    {
        public int count;

        public override void Init()
        {
            base.Init();
            this.PlusPerStat.Damage = 10;
            this.PlusStat.cri = 5;
            this.PlusStat.dod = -7;
            count = 0;
        }

        public void Turn()
        {
            count = 0;
        }

        public void AttackEffect(BattleChar hit, SkillParticle SP, int DMG, bool Cri)
        {
            if (DMG >= 1 && count == 0)
            {
                int ran = RandomManager.RandomInt(this.BChar.GetRandomClass().Main, 0, 4);
                switch (ran)
                {
                    case 0:
                        hit.BuffAdd("B_HakureiReimu_F_E_1_0", this.BChar);
                        break;
                    case 1:
                        hit.BuffAdd("B_HakureiReimu_F_E_1_1", this.BChar);
                        break;
                    case 2:
                        hit.BuffAdd("B_HakureiReimu_F_E_1_2", this.BChar);
                        break;
                    case 3:
                        hit.BuffAdd("B_HakureiReimu_F_E_1_3", this.BChar);
                        break;
                }
            }
        }
    }
}