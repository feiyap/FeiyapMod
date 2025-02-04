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
using BasicMethods;
namespace Yuyuko
{
	/// <summary>
	/// 亡乡「亡我乡 -宿罪-」
	/// 增加20返魂值。
	/// 华胥 - 超额治疗自己&a体力(目标已损失的最大体力值的25%)。
	/// 葬送 - 亡者召还3。
	/// 幽冥蝶 - 回合开始时，降低10%最大体力值。
	/// 人魂蝶 - 可以无视嘲讽状态被选中。
	/// </summary>
    public class S_YuyukoF_0:Skill_Extended, IP_SkillSelfExcept
    {
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            BattleSystem.instance.GetBattleValue<BV_YuyukoF_P>().setFanhun(20);

            if (P_YuyukoF.Yuyu == P_YuyukoF.YuyuState.State_Huaxu)
            {
                this.BChar.Heal(this.BChar, (int)(BattleSystem.instance.GetBattleValue<BV_YuyukoF_P>().dieList[Targets[0]] * 0.25), true, false);
            }
        }

        public bool SelfExcept(SkillLocation skillLoaction)
        {
            P_YuyukoF.DeadRevive(this.BChar, 3);
            return true;
        }
    }
}