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
	/// 赝造龙鳞
	/// 攻击改为指向自己。触发后移除。
	/// </summary>
    public class B_Pachi_0_0:Buff, IP_SkillUse_User
    {
        public void SkillUse(Skill SkillD, List<BattleChar> Targets)
        {
            Targets.Clear();
            Targets.Add(this.BChar);
            this.SelfStackDestroy();
        }
    }
}