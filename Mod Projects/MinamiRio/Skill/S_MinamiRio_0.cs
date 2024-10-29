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
namespace MinamiRio
{
	/// <summary>
	/// 替弓
	/// 使自身切换<color=#48D1CC>单弓</color>/<color=#FFD700>和弓</color>状态。
	/// 作为固定技能时，<color=#DC143C>皆中</color>解除时变为可以使用的状态。
	/// </summary>
    public class S_MinamiRio_0:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            if (this.BChar.BuffFind("B_MinamiRio_P1"))
            {
                this.BChar.BuffReturn("B_MinamiRio_P1").SelfDestroy();
                this.BChar.BuffAdd("B_MinamiRio_P2", this.BChar);
            }
            else if (this.BChar.BuffFind("B_MinamiRio_P2"))
            {
                this.BChar.BuffReturn("B_MinamiRio_P2").SelfDestroy();
                this.BChar.BuffAdd("B_MinamiRio_P1", this.BChar);
            }
        }
    }
}