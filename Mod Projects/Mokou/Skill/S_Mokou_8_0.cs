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
namespace Mokou
{
	/// <summary>
	/// 「不死之身的舍身击」
	/// 造成自身50%最大体力值的伤害
	/// </summary>
    public class S_Mokou_8_0:Skill_Extended
    {
        public override string DescExtended(string desc)
        {
            return base.DescExtended(desc).Replace("&a", ((int)Misc.PerToNum((float)this.BChar.GetStat.maxhp, 50f)).ToString());
        }
        public override void FixedUpdate()
        {
            base.FixedUpdate();
            this.SkillBasePlus.Target_BaseDMG = (int)Misc.PerToNum((float)this.BChar.GetStat.maxhp, 50f);
        }
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);
            this.SkillBasePlus.Target_BaseDMG = (int)Misc.PerToNum((float)this.BChar.GetStat.maxhp, 50f);
        }
    }
}