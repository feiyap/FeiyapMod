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
namespace Jhin
{
	/// <summary>
	/// 要耐心…
	/// 艺术需要精心雕琢…
	/// </summary>
    public class B_Jhin_7:Buff
    {
        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
            this.LucySkillExBuff = (BuffSkillExHand)Skill_Extended.DataToExtended("SE_Jhin_P_5");
        }

        public override bool CanSkillBuffAdd(Skill AddedSkill, int Index)
        {
            return AddedSkill.Master == this.BChar && AddedSkill.ExtendedFind_DataName("SE_Jhin_P_5") == null;
        }
    }
}