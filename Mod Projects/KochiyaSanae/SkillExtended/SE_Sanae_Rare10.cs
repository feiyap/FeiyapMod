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
	/// 开海的奇迹
	/// 造成&a(20%)额外伤害或&b(20%)额外治疗。
	/// </summary>
    public class SE_Sanae_Rare10:Skill_Extended
    {
        public override string ExtendedDes()
        {
            return base.ExtendedDes().Replace("&a", ((int)(this.BChar.GetStat.atk * 0.3f)).ToString()).Replace("&b", ((int)(this.BChar.GetStat.reg * 0.3f)).ToString());
        }

        public override void Init()
        {
            base.Init();
            if (this.MySkill.IsDamage)
            {
                this.SkillBasePlus.Target_BaseDMG = (int)(this.BChar.GetStat.atk * 0.3f);
            }
            if (this.MySkill.IsHeal)
            {
                this.SkillBasePlus.Target_BaseHeal = (int)(this.BChar.GetStat.reg * 0.3f);
            }
        }
    }
}