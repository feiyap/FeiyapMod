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
namespace Kirito
{
	/// <summary>
	/// 抽2
	/// </summary>
    public class S_Kirito_LucyD_0:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            for (int i = 0; i < 2; i++)
            {
                BattleSystem.instance.AllyTeam.Draw(new BattleTeam.DrawInput(this.Drawinput));
            }
        }

        public void Drawinput(Skill skill)
        {
            skill.NotCount = true;
        }
    }
}