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
namespace Parsee
{
	/// <summary>
	/// 追击
	/// </summary>
    public class S_Parsee_Rare_1_0:Skill_Extended
    {
        public override void Init()
        {
            base.Init();
            this.IsDamage = true;
            this.SkillBasePlus.Target_BaseDMG = (int)(this.BChar.GetStat.reg * 0.4f);
        }
    }
}