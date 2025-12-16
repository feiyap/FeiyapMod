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
namespace Morichika
{
	/// <summary>
	/// 溢价
	/// 使目标技能在本场战斗中费用提升 1 点、造成的伤害量/治疗量提升80%。
	/// 使目标技能的持有者获得“保修服务”。
	/// </summary>
    public class S_Morichika_2:Skill_Extended
    {
        public override void SkillTargetSingle(List<Skill> Targets)
        {
            base.SkillTargetSingle(Targets);
            
            SE_Morichika_2 extended = new SE_Morichika_2();
            Targets[0].ExtendedAdd_Battle(extended);

            Targets[0].Master.BuffAdd("B_Morichika_P", this.BChar);
        }
    }
}