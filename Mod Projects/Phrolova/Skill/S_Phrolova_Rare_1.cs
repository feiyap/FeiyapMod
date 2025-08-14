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
namespace Phrolova
{
	/// <summary>
	/// 往日深渊的圆舞曲
	/// 仅在持有“定音”增益时才可释放。
	/// 移除“定音”增益。
	/// </summary>
    public class S_Phrolova_Rare_1:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            this.BChar.BuffReturn("B_Phrolova_P_2")?.SelfDestroy();
        }

        public override bool Terms()
        {
            return this.BChar.BuffFind("B_Phrolova_P_2");
        }
    }
}