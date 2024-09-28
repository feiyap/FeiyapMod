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
namespace Mokou
{
	/// <summary>
	/// 「不死鸟重生」
	/// 赤魂层数-1（可以再重生一次）。
	/// 直到下一回合开始前，受到的伤害减少50%。
	/// 本次战斗中，每层赤魂提供的最大生命值多5。
	/// </summary>
    public class S_Mokou_R_2:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            MasterAudio.PlaySound("Mokou_R2_1", 1f, null, 0f, null, null, false, false);
            if (this.BChar.BuffFind("B_Mokou_0",false))
            {
                for (int i = 0; i < this.BChar.BuffReturn("B_Mokou_0",false).StackNum; i++)
                {
                    this.BChar.BuffReturn("B_Mokou_0", false).SelfStackDestroy();
                }
            }
            base.SkillUseSingle(SkillD, Targets);
        }
    }
}