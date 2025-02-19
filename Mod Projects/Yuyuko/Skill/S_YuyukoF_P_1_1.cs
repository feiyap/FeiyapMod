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
	/// 转化<color=#4876FF>幽冥蝶</color>
	/// 将目标技能转化为<color=#4876FF>幽冥蝶</color>施加在任意敌人身上。&a
	/// </summary>
    public class S_YuyukoF_P_1_1:Skill_Extended
    {
        public override bool ButtonSelectTerms()
        {
            return BattleSystem.instance.EnemyList.FindAll((BattleEnemy be) => be.BuffFind("B_YuyukoF_Butterfly_M")).Count == 0;
        }

        public override string DescExtended(string desc)
        {
            string str = "";
            if (BattleSystem.instance != null && BattleSystem.instance.EnemyList.FindAll((BattleEnemy be) => be.BuffFind("B_YuyukoF_Butterfly_M")).Count > 0)
            {
                str = ModManager.getModInfo("Yuyuko").localizationInfo.SystemLocalizationUpdate("S_YuyukoF_P_1_1/Text");
            }

            return base.DescExtended(desc).Replace("&a", str);
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            Targets[0].BuffAdd("B_YuyukoF_Butterfly_M", this.BChar);

            BattleSystem.instance.GetBattleValue<BV_YuyukoF_P>().str_S.Except();
            BattleSystem.instance.GetBattleValue<BV_YuyukoF_P>().setButterfly(true);
        }
    }
}