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
namespace Morichika
{
	/// <summary>
	/// 保修服务
	/// 攻击力、防御力、治疗力提升 &a% (&user最大体力值的25%)。
	/// </summary>
    public class B_Morichika_P:Buff
    {
        public override void Init()
        {
            base.Init();
            this.PlusPerStat.Damage = MAXHPPER;
            this.PlusStat.def = MAXHPPER;
            this.PlusPerStat.Heal = MAXHPPER;
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();

            this.PlusPerStat.Damage = MAXHPPER;
            this.PlusStat.def = MAXHPPER;
            this.PlusPerStat.Heal = MAXHPPER;
        }

        public override string DescExtended()
        {
            string username = "";

            if (base.Usestate_L != null)
            {
                username = base.Usestate_L.Info.Name;
            }

            return this.BuffData.Description.Replace("&a", MAXHPPER.ToString()).Replace("&user", username);
        }

        int MAXHPPER
        {
            get
            {
                if (BattleSystem.instance != null && this.Usestate_F != null)
                {
                    return (int)(this.Usestate_F.GetStat.maxhp * 0.25);
                }
                return 0;
            }
        }
    }
}