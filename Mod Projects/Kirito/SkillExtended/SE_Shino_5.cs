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
namespace Kirito
{
	/// <summary>
	/// 诗乃5
	/// </summary>
    public class SE_Shino_5:Skill_Extended
    {
        public override void Init()
        {
            base.Init();
            this.PlusSkillStat.cri = 100f;
            float num = (float)this.MySkill.GetCriPer(this.BChar, 0);
            this.SkillBasePlus.Target_BaseDMG = (int)Misc.PerToNum((float)this.MySkill.TargetDamage, (float)((int)(num - 100f)));
        }
    }
}