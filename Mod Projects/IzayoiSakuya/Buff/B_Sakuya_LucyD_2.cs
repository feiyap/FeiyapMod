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
	/// 膨胀空间
	/// 使用过载技能时抽取1个技能。
	/// </summary>
    public class B_Sakuya_LucyD_2:Buff, IP_SkillUse_Target, IP_Dodge
    {
        public int count = 0;

        public void AttackEffect(BattleChar hit, SkillParticle SP, int DMG, bool Cri)
        {
            if ((SP.SkillData.IsDamage || SP.SkillData.IsHeal) && Cri)
            {
                if (count < 4)
                {
                    BattleSystem.instance.AllyTeam.Draw();
                    count++;
                }
            }
        }

        public void Dodge(BattleChar Char, SkillParticle SP)
        {
            if (Char == this.BChar)
            {
                if (count < 4)
                {
                    BattleSystem.instance.AllyTeam.Draw();
                    count++;
                }
            }
        }
    }
}