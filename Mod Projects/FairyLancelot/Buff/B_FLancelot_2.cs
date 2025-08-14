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
namespace FairyLancelot
{
	/// <summary>
	/// 你已深陷于我
	/// 只能指定&user为目标。
	/// 受到&user以外的伤害减少50%；受到来自&user的伤害提高50%。
	/// 若被&user击杀，获得100金币，好感度+2。
	/// </summary>
    public class B_FLancelot_2 : B_Taunt, IP_Awake, IP_SkillUse_User, IP_DamageTakeChange, IP_DamageTake
    {
        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
        }

        public override void SkillUse(Skill SkillD, List<BattleChar> Targets)
        {
            if (Targets[0].Info.Ally != this.BChar.Info.Ally)
            {
                Targets.Clear();
                Targets.Add(base.Usestate_L);
            }
        }

        public int DamageTakeChange(BattleChar Hit, BattleChar User, int Dmg, bool Cri, bool NODEF = false, bool NOEFFECT = false, bool Preview = false)
        {
            if (User == this.Usestate_L)
            {
                return Dmg += Dmg * 150 / 100;
            }
            if (User != this.Usestate_L)
            {
                return Dmg += Dmg * 50 / 100;
            }

            return Dmg;
        }

        public void DamageTake(BattleChar User, int Dmg, bool Cri, ref bool resist, bool NODEF = false, bool NOEFFECT = false, BattleChar Target = null)
        {
            if (User == this.Usestate_L && Dmg >= this.BChar.HP)
            {
                PlayData.TSavedata.GetCustomValue<CV_FairyLancelotGood>().heartPoint += 2;
                this.SelfDestroy();
            }
        }

        public override string DescExtended()
        {
            string username = "兰斯洛特";
            if (base.Usestate_L != null)
            {
                username = base.Usestate_L.Info.Name;
            }

            return this.BuffData.Description.Replace("&user", username);
        }
    }
}