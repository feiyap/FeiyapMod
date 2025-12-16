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
namespace Jhin
{
	/// <summary>
	/// 万众倾倒
	/// 仅能对持有干扰减益的敌人造成伤害和施加减益。
	/// </summary>
    public class S_Jhin_3:Skill_Extended, IP_ParticleOut_Before
    {
        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
        }

        public void ParticleOut_Before(Skill SkillD, List<BattleChar> Targets)
        {
            for (int i = 0; i < Targets.Count; i++)
            {

                if (Targets[i].GetBuffs(BattleChar.GETBUFFTYPE.CC, false, false).Count == 0)
                {
                    Targets.RemoveAt(i);
                    i--;
                }
            }

            if (Targets.Count == 0)
            {
                Targets.Add(BattleSystem.instance.AllyTeam.DummyChar);
            }
        }

        public override bool Terms()
        {
            return base.Terms() && (BattleSystem.instance.EnemyList.Find((BattleEnemy a) => a.GetBuffs(BattleChar.GETBUFFTYPE.CC, false, false).Count != 0) != null) ;
        }
    }
}