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
namespace Suwako
{
	/// <summary>
	/// 源符「诹访清水」
	/// <color=#008B45>旋回</color> - 对随机敌人释放后抽取1个技能。
	/// </summary>
    public class S_Suwako_1: SkillExtend_Suwako, IP_SkillSelfToDeck
    {
        public void SelfAddToDeck(SkillLocation skillLoaction)
        {
            BattleSystem.DelayInput(BattleSystem.instance.SkillRandomUseIenum(this.BChar, this.MySkill, false, true, false));
            BattleSystem.instance.AllyTeam.Draw();
        }
    }
}