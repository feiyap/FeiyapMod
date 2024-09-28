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
namespace HouraisanKaguya
{
	/// <summary>
	/// 无差别放火之符
	/// 使用技能造成伤害时，对敌人施加烧伤痛苦减益。
	/// </summary>
    public class Equip_FMokou_Spell:EquipBase, IP_SkillUse_Target
    {
        public override void Init()
        {
            base.Init();
            this.PlusPerStat.MaxHP = 15;
            this.PlusPerStat.Damage = 10;
            this.PlusStat.HIT_DOT = 20f;
        }

        public void AttackEffect(BattleChar hit, SkillParticle SP, int DMG, bool Cri)
        {
            if (DMG > 0)
            {
                hit.BuffAdd("B_Mokou_T_1", this.BChar, false, 0, false, -1, false);
            }
        }
    }
}