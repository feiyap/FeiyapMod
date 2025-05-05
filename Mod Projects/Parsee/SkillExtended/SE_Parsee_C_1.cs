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
namespace Parsee
{
	/// <summary>
	/// 释放时，为未拥有诅咒的敌人施加1层诅咒，为未拥有祸水的友军施加1层祸水(成功率130%)。
	/// 2费及以上
	/// </summary>
    public class SE_Parsee_C_1:Skill_Extended
    {
        public override bool CanSkillEnforce(Skill MainSkill)
        {
            return MainSkill.AP >= 2;
        }

        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
        }

        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            base.SkillUseSingle(SkillD, Targets);

            foreach (BattleChar bc in BattleSystem.instance.EnemyList)
            {
                if (!bc.BuffFind("B_Parsee_P_1"))
                {
                    bc.BuffAdd("B_Parsee_P_1", this.BChar);
                }
            }

            foreach (BattleChar bc in BattleSystem.instance.AllyList)
            {
                if (!bc.BuffFind("B_Parsee_P_0"))
                {
                    bc.BuffAdd("B_Parsee_P_0", this.BChar, false, -70);
                }
            }
        }
    }
}