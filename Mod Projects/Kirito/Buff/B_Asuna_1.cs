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
	/// 亚丝娜1
	/// </summary>
    public class B_Asuna_1:Buff, IP_SkillUseHand_Team
    {
        public override void Init()
        {
            base.Init();
            this.LucySkillExBuff = new B_Asuna_1_0();
        }

        public void SKillUseHand_Team(Skill skill)
        {
            base.SelfDestroy(false);
        }
    }
}