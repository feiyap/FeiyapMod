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
namespace KirisameMarisa
{
	/// <summary>
	/// 卫星幻觉
	/// 使用技能时减少一层，造成额外&a点伤害<color=#FF7A33>(攻击力的100%)</color>。
	/// </summary>
    public class B_KirisameMarisa_Rare_12:Buff, IP_SkillUse_User
    {
        public override string DescExtended()
        {
            return base.DescExtended().Replace("&a", ((int)(this.BChar.GetStat.atk * 1.0f)).ToString());
        }

        public void SkillUse(Skill SkillD, List<BattleChar> Targets)
        {
            if (SkillD.IsDamage && !SkillD.PlusHit && SkillD.Master == this.BChar)
            {
                Skill_Extended skill_Extended = new Skill_Extended();
                skill_Extended.PlusSkillPerStat.Damage = 100;
                SkillD.ExtendedAdd(skill_Extended);
                SelfStackDestroy();
            }
        }
    }
}