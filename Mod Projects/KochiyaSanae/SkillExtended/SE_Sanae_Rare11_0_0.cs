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
namespace KochiyaSanae
{
	/// <summary>
	/// 五芒星的奇迹
	/// </summary>
    public class SE_Sanae_Rare11_0_0:Skill_Extended
    {
        public override void Init()
        {
            base.Init();
            if (this.MySkill.IsDamage)
            {
                this.SkillBasePlus.Target_BaseDMG = (int)(this.BChar.GetStat.atk);
            }
            if (this.MySkill.IsHeal)
            {
                this.SkillBasePlus.Target_BaseHeal = (int)(this.BChar.GetStat.reg);
            }
        }
    }
}