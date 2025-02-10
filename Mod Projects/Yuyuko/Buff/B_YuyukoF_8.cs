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
	/// 醉梦蝶
	/// 受到的伤害降低为0，但&user增加等量于伤害值的返魂值。
	/// &user陷入永眠时立即解除。
	/// </summary>
    public class B_YuyukoF_8:Buff, IP_DamageChange, IP_FanhunChange
    {
        public int DamageChange(Skill SkillD, BattleChar Target, int Damage, ref bool Cri, bool View)
        {
            if (!View)
            {
                BattleSystem.instance.GetBattleValue<BV_YuyukoF_P>().setFanhun(Damage);
            }

            Damage = 0;

            return Damage;
        }

        public void FanhunChange(int count)
        {
            if (count >= 100)
            {
                this.SelfDestroy();
            }
        }

        public override string DescExtended()
        {
            return base.DescExtended().Replace("&user", this.Usestate_F.Info.Name);
        }
    }
}