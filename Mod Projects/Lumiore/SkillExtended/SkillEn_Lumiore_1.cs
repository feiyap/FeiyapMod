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
namespace Lumiore
{
	/// <summary>
	/// 龙之
	/// 觉醒：费用-2。
	/// </summary>
    public class SkillEn_Lumiore_1:Skill_Extended
    {
        public override void Init()
        {
            base.Init();
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            if (this.BChar.MyTeam.MAXAP >= 7)
            {
                this.APChange = -2;
            }
            else
            {
                this.APChange = 0;
            }
        }
    }
}