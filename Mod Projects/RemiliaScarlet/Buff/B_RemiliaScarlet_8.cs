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
namespace RemiliaScarlet
{
	/// <summary>
	/// 血狱王冠
	/// 造成伤害时，将其中50%转化为痛苦伤害。
	/// 造成痛苦伤害时，额外造成&a伤害(&user最大体力值的25%)。
	/// </summary>
    public class B_RemiliaScarlet_8:Buff, IP_DamageChange
    {
        public override void Init()
        {
            base.Init();
        }
        
        public int DamageChange(Skill SkillD, BattleChar Target, int Damage, ref bool Cri, bool View)
        {
            if (!View && Damage > 0)
            {
                Target.Damage(this.BChar, (int)(Damage / 2 + this.Usestate_F.GetStat.maxhp * 0.25f), Cri, true, false, 0, false, false, false);
                Damage = Damage * 50 / 100;
            }

            return Damage;
        }

        public override string DescExtended()
        {
            string username = "蕾米莉亚";
            if (base.Usestate_L != null)
            {
                username = base.Usestate_L.Info.Name;
            }

            return this.BuffData.Description.Replace("&user", username)
                                            .Replace("&a", ((int)(this.Usestate_F.GetStat.maxhp * 0.25f)).ToString());
        }
    }
}