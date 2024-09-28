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
namespace Ralmia
{
	/// <summary>
	/// 古老的创造物
	/// 创造物。
	/// </summary>
    public class S_Ralmia_1:Skill_Extended
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            if (this.BChar.BuffFind("B_Ralmia_0", false))
            {
                BattleSystem.instance.AllyTeam.Draw();
                BattleTeam allyTeam = BattleSystem.instance.AllyTeam;
                int ap = allyTeam.AP;
                allyTeam.AP = ap + 1;
            }

            if (this.BChar.BuffFind("B_Ralmia_1", false))
            {
                BattleTeam allyTeam = BattleSystem.instance.AllyTeam;
                int ap = allyTeam.AP;
                allyTeam.AP = ap + 1;
            }
        }
        public override void FixedUpdate()
        {
            base.FixedUpdate();
            if (this.BChar.BuffFind("B_Ralmia_1", false))
            {
                if (!this.flag)
                {
                    this.flag = true;
                    base.SkillParticleOn();
                    this.NotCount = true;
                    return;
                }
            }
        }
        public bool flag;
    }
}