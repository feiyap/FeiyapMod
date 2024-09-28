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
namespace HakureiReimu
{
	/// <summary>
	/// 梦境「二重大结界」
	/// 以60%的干扰成功率对其他所有敌人施加。
	/// </summary>
    public class S_HakureiReimu_F_7_3: S_HakureiReimu_F_7
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);

            for (int i = 0; i < BattleSystem.instance.EnemyTeam.AliveChars.Count; i++)
            {
                if (BattleSystem.instance.EnemyTeam.AliveChars[i] != Targets[0])
                {
                    BattleSystem.instance.EnemyTeam.AliveChars[i].BuffAdd("B_HakureiReimu_F_7", this.BChar, false, -40);
                }
            }
        }
    }
}