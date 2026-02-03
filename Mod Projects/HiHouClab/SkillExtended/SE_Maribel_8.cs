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
namespace HiHouClab
{
	/// <summary>
	/// 费用为0，附带放逐
	/// </summary>
    public class SE_Maribel_8:Skill_Extended
    {
        public override void Init()
        {
            base.Init();
            this.APChange = -99;
            this.MySkill.isExcept = true;
        }
    }
}