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
namespace PatchouliKnowledge
{
	/// <summary>
	/// 元素紊乱
	/// 攻击有 &a 概率失效。
	/// 触发后减少 1 层。
	/// </summary>
    public class B_Pachi_0_1_1:Buff, IP_SkillUse_User
    {
        public void SkillUse(Skill SkillD, List<BattleChar> Targets)
        {
            if (RandomManager.RandomPer(this.BChar.GetRandomClass().Main, 100, (int)(10 * StackNum)))
            {
                Targets.Clear();
                this.SelfStackDestroy();
            }
        }

        public override string DescExtended()
        {
            if (BattleSystem.instance == null)
            {
                return this.BuffData.Description.Replace("&a", (10).ToString());
            }
            return this.BuffData.Description.Replace("&a", ((int)(10 * StackNum)).ToString());
        }
    }
}