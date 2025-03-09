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
namespace FFAce
{
	/// <summary>
	/// 赤红之炎
	/// 每层使[红焰轮舞]的伤害增加&a(攻击力的40%)。
	/// 叠加至3层时，生成1张[赤红之炎]（触发时解除）。
	/// </summary>
    public class B_FFAce_0:Buff
    {
        public override void Init()
        {
            base.Init();
            if (this.StackNum == 3)
            {
                Skill tmpSkill = Skill.TempSkill("S_FFAce_0_Ex", this.Usestate_F, this.Usestate_F.MyTeam);
                BattleSystem.instance.AllyTeam.Add(tmpSkill, true);
                SelfDestroy();
            }
        }

        public override string DescExtended()
        {
            return base.DescExtended().Replace("&a", ((int)(this.Usestate_F.GetStat.atk * 0.4f)).ToString());
        }
    }
}