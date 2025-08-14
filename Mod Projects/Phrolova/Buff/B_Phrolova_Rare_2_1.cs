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
namespace Phrolova
{
	/// <summary>
	/// 你我形同陌路
	/// 使用固定能力后，清除自身过载。
	/// </summary>
    public class B_Phrolova_Rare_2_1:Buff, IP_SkillUse_User, IP_DealDamage
    {
        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
        }

        public void SkillUse(Skill SkillD, List<BattleChar> Targets)
        {
            if (SkillD.BasicSkill)
            {
                this.BChar.Overload = 0;
            }
        }

        public void DealDamage(BattleChar Take, int Damage, bool IsCri, bool IsDot)
        {
            if (Damage >= 1)
            {
                this.BChar.Heal(this.BChar, (float)((int)((float)Damage * 0.2f)), false, false, null);
            }
        }
    }
}