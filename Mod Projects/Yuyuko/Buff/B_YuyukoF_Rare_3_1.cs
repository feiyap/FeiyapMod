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
namespace Yuyuko
{
	/// <summary>
	/// 浮月蝶
	/// 所有造成的伤害额外增加&a(35%)点，最多触发 10 次。
	/// 当前触发次数：&b
	/// </summary>
    public class B_YuyukoF_Rare_3_1:Buff, IP_SkillUse_User
    {
        public int count = 0;

        public override string DescExtended()
        {
            return base.DescExtended().Replace("&a", ((int)(this.BChar.GetStat.atk * 0.47f)).ToString())
                                      .Replace("&b", count.ToString());
        }
        
        public void SkillUse(Skill SkillD, List<BattleChar> Targets)
        {
            if (SkillD.IsDamage && SkillD.Master == this.BChar && count < 10)
            {
                Skill_Extended skill_Extended = new Skill_Extended();
                skill_Extended.PlusSkillPerStat.Damage = 47;
                SkillD.ExtendedAdd(skill_Extended);
                count++;
            }

            if (count == 10)
            {
                SelfDestroy();
            }
        }
    }
}