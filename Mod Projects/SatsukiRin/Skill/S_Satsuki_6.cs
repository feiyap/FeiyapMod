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
	/// 秋之花「白诘草」
	/// </summary>
    public class S_Satsuki_6:Skill_Extended
    {
        public override void HandInit()
        {
            base.HandInit();
            this.SkillBasePlus.Target_BaseDMG = 0;
            this.PlusSkillPerStat.Heal = 0;
            this.IsDamage = true;
            this.SkillBasePlusPreview.Target_BaseDMG = (int)(this.BChar.GetStat.reg * 1.1);
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            Targets[0].Damage(this.BChar, (int)((double)this.BChar.GetStat.reg * 1.1), false, true, false, 0, false, false, false);
        }

        public override string DescExtended(string desc)
        {
            return base.DescExtended(desc).Replace("%a", ((int)(this.BChar.GetStat.reg * 1.1)).ToString());
        }
    }
}