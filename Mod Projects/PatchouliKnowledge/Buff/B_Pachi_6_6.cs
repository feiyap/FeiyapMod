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
namespace PatchouliKnowledge
{
	/// <summary>
	/// 月之面纱
	/// 隐匿。
	/// 使用自己的技能时解除。
	/// </summary>
    public class B_Pachi_6_6:Buff, IP_SkillUse_Team
    {
        public override void Init()
        {
            base.Init();
            this.PlusStat.invincibility = true;
        }

        public void SkillUseTeam(Skill skill)
        {
            if (skill.Master == this.BChar)
            {
                this.SelfDestroy();
            }
        }

    }
}