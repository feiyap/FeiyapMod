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
namespace szb_elena
{
	/// <summary>
	/// 独角兽
	/// 治疗自己和体力最低的调查员&a体力(治疗力的60%)。
	/// </summary>
    public class S_szb_elena_3_0:Skill_Extended
    {
        public override string DescExtended(string desc)
        {
            return base.DescExtended(desc).Replace("&a", ((int)(this.BChar.GetStat.reg * 0.6)).ToString());
        }
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            this.BChar.Heal(this.BChar, (float)(this.BChar.GetStat.reg * 0.6), false, false, null);
            BattleSystem.instance.AllyTeam.FindChar_LowHP().Heal(this.BChar, (float)(this.BChar.GetStat.reg * 0.6), false, false, null);
            
        }
    }
}