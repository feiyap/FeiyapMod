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
	/// 切换
	/// 桐人会以一半的效果重复释放打出的技能。
	/// </summary>
    public class B_Asuna_7:Buff, IP_SkillUseHand_Team
    {
        public override void Init()
        {
            base.Init();
        }
        
        public void SKillUseHand_Team(Skill skill)
        {
            if (skill.Master == this.BChar && skill.IsDamage)
            {
                BattleSystem.DelayInputAfter(BattleSystem.instance.SkillRandomUseIenum(base.Usestate_F, skill.CloneSkill(true, base.Usestate_F, null, false), false, false, false));
            }
        }
    }
}