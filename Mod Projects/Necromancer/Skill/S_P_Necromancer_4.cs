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
namespace Necromancer
{
	/// <summary>
	/// 朽骨重肉
	/// 强化施加的血肉活化与白骨增生。
	/// 分别赋予濒死保护与体力极限保护。
	/// </summary>
    public class S_P_Necromancer_4:Skill_Extended
    {
        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            Targets.ForEach(target => target.BuffAdd("B_S_Necromancer_5", BChar));
        }
    }
}