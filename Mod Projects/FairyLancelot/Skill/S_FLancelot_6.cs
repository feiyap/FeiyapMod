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
	/// 妖精湖的加护
	/// 如果目标为自身，其他队友获得一半数值的增益。
	/// </summary>
    public class S_FLancelot_6:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            if (Targets[0] == this.BChar)
            {
                foreach (BattleChar bc in BattleSystem.instance.AllyList)
                {
                    if (bc != this.BChar)
                    {
                        bc.BuffAdd("B_FLancelot_6_0", this.BChar);
                    }
                }
            }
        }
    }
}