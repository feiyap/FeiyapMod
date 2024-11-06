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
	/// 土著神「宝永四年的赤蛙」
	/// 倒计时期间，每次触发<color=#008B45>旋回</color>，或是每使用4个技能，对所有敌人造成40%伤害。
	/// <color=#008B45>旋回</color> - 对所有敌人施加“防御力降低30%”，持续1回合。
	/// </summary>
    public class S_Suwako_4:Skill_Extended, IP_SkillSelfToDeck
    {
        public void SelfAddToDeck(SkillLocation skillLoaction)
        {
            BattleEnemy be = BattleSystem.instance.EnemyList.Random(BChar.GetRandomClass().Main);
            be.BuffAdd("B_Suwako_Dot", this.BChar);
            be.BuffAdd("B_Suwako_Dot", this.BChar);
        }
    }
}