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
    /// 抵押
    /// 当前抵押的技能是：&skill
    /// </summary>
    public class B_Morichika_3 : Buff, IP_PlayerTurn
    {
        public void Turn()
        {
            if (BattleSystem.instance.GetBattleValue<BV_Morichika>() == null)
            {
                BattleSystem.instance.BattleValues.Add(new BV_Morichika());
            }

            if (BattleSystem.instance.GetBattleValue<BV_Morichika>().morichika_3_skill != null)
            {
                BattleSystem.instance.AllyTeam.Add(BattleSystem.instance.GetBattleValue<BV_Morichika>().morichika_3_skill, true);
            }

            this.SelfDestroy();
        }

        public override string DescExtended()
        {
            string skillname = "";

            if (BattleSystem.instance != null)
            {
                skillname = BattleSystem.instance.GetBattleValue<BV_Morichika>().morichika_3_skill.MySkill.Name;
            }

            return this.BuffData.Description.Replace("&skill", skillname);
        }
    }
}