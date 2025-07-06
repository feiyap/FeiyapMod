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
namespace FairyLancelot
{
	/// <summary>
	/// 妖精剑舞
	/// 下 1 次使用技能时恢复 1 点法力值。
	/// </summary>
    public class B_FLancelot_1:Buff, IP_SkillUseHand_Team
    {
        public void SKillUseHand_Team(Skill skill)
        {
            if (skill.Master == this.BChar)
            {
                this.BChar.MyTeam.AP++;
                base.SelfDestroy(false);
            }
        }
        
        public override void Init()
        {
            base.Init();
        }
    }
}