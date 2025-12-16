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
namespace CirnoBlizzard
{
	/// <summary>
	/// 圣洁之心
	/// 使所有非“输出”职业的调查员获得“圣洁之心”。
	/// 使所有“输出”职业的调查员获得“污秽之心”。
	/// </summary>
    public class S_Boss_Cirno_P3_0:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);

            this.TargetBuff = null;

            foreach (BattleChar bc in BattleSystem.instance.AllyList)
            {
                if (bc.Info.GetData.Role.Key == GDEItemKeys.CharRole_Role_DPS)
                {
                    bc.BuffAdd("B_Boss_Cirno_P3_0", this.BChar);
                }
                else
                {
                    bc.BuffAdd("B_Boss_Cirno_P3_0_0", this.BChar);
                }
            }
        }
    }
}