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
using NLog.Targets;
namespace Necromancer
{
	/// <summary>
	/// 相信我，这只是番茄汁
	/// 若目标生命值为满，额外施加一层血肉活化。
	/// </summary>
    public class S_Necromancer_2:Skill_Extended
    {
        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
        }
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            if (Targets[0].HP >= Targets[0].GetStat.maxhp)
            {
                Targets[0].BuffAdd("B_Necromancer_5", BChar, false, 200);
            }
        }
    }
}