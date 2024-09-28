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
namespace HatsuneMiku
{
	/// <summary>
	/// あなたの歌姬
	/// 超额恢复等量与目标身上[未来之音]层数的数值。
	/// 保护体力极限2回合。
	/// </summary>
    public class S_HatsuneMiku_9:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);

            Targets[0].Heal(this.BChar, Targets[0].BuffReturn("B_HatsuneMiku_P", false).StackNum, false, true, null);
            //Targets[0].BuffAdd("B_Public_30", this.BChar, false, 0, false, -1, false);
        }
    }
}