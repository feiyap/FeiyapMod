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
namespace HiHouClab
{
	/// <summary>
	/// 天空的格林尼治
	/// 击杀敌人时，对其他所有敌人施加 2 层“量子隧穿”。
	/// </summary>
    public class S_Renko_3:Skill_Extended
    {
        public override void SkillKill(SkillParticle SP)
        {
            base.SkillKill(SP);

            foreach (BattleEnemy be in BattleSystem.instance.EnemyList)
            {
                be.BuffAdd("B_Renko_1", this.BChar);
                be.BuffAdd("B_Renko_1", this.BChar);
            }
        }
    }
}