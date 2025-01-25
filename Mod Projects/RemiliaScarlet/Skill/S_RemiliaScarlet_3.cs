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
namespace RemiliaScarlet
{
	/// <summary>
	/// 夜符「Demon King Cradle」
	/// 如果目标身上没有「绯夜」，赋予「绯夜」。
	/// 如果目标身上有「绯夜」，则额外造成%a伤害，并赋予目标以外的所有敌人「绯夜」。
	/// </summary>
    public class S_RemiliaScarlet_3:Skill_Extended
    {
        public override void Init()
        {
            base.Init();
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {

        }
    }
}