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
	/// 夏之花「流风中的向日葵色」
	/// </summary>
    public class S_Satsuki_5:Skill_Extended
    {
        public override void HandInit()
        {
            base.HandInit();
            this.SkillBasePlus.Target_BaseDMG = 0;
            this.PlusSkillPerStat.Heal = 0;
            this.IsDamage = true;
            this.SkillBasePlusPreview.Target_BaseDMG = 0;
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);
            this.IsDamage = false;
            this.SkillBasePlus.Target_BaseDMG = 0;
            this.PlusSkillPerStat.Heal = 0;

            this.TargetBuff = null;

            if (!Targets[0].Info.Ally)
            {
                this.IsHeal = false;
                this.IsDamage = true;
                this.SkillBasePlus.Target_BaseDMG = 0;
                this.PlusSkillPerStat.Heal = -99999;
                this.SkillBasePlus.Target_BaseHeal = 0;
                Targets[0].BuffAdd("B_Satsuki_5_0", this.BChar, false, 0, false, -1, false);
            }
            else
            {
                Targets[0].BuffAdd("B_Satsuki_5", this.BChar, false, 0, false, -1, false);
            }
        }
    }
}