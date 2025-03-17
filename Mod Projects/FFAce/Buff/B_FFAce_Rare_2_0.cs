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
namespace FFAce
{
	/// <summary>
	/// 固定能力费用减少
	/// 固定能力的费用减少1点。
	/// </summary>
    public class B_FFAce_Rare_2_0:Buff, IP_SkillUse_User
    {
        public override void Init()
        {
            base.Init();
            this.PlusStat.PlusMPUse.PlusMP_Fixed = -1;
        }
        
        public void SkillUse(Skill SkillD, List<BattleChar> Targets)
        {
            if (SkillD.BasicSkill)
            {
                this.SelfStackDestroy();
            }
        }
    }
}