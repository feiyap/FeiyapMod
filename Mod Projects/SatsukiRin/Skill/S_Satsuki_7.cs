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
namespace SatsukiRin
{
	/// <summary>
	/// 冬之花「Windflower」
	/// 幻灭10 - 额外治疗%a。
	/// </summary>
    public class S_Satsuki_7:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);
            this.IsDamage = false;
            this.SkillBasePlus.Target_BaseDMG = 0;
            this.PlusSkillPerStat.Heal = 0;

            this.TargetBuff = null;

            for (int i = 0;i<Targets.Count;i++)
            {
                if (!Targets[i].Info.Ally)
                {
                    this.IsHeal = false;
                    this.IsDamage = true;
                    this.SkillBasePlus.Target_BaseDMG = 0;
                    this.PlusSkillPerStat.Heal = -99999;
                    this.SkillBasePlus.Target_BaseHeal = 0;
                    Targets[i].BuffAdd("B_Satsuki_7_0", this.BChar, false, 0, false, -1, false);
                }
                else
                {
                    Targets[i].BuffAdd("B_Satsuki_7", this.BChar, false, 0, false, -1, false);
                }
            }
            
        }
    }
}