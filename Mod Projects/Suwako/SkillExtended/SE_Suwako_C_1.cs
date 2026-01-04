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
	/// <color=#008B45>旋回</color> - 恢复 1 点法力值，抽取 1 个技能。
	/// </summary>
    public class SE_Suwako_C_1:Skill_Extended, IP_SkillSelfToDeck
    {
        public void SelfAddToDeck(SkillLocation skillLoaction)
        {
            BattleSystem.DelayInput(this.Del());
        }

        private IEnumerator Del()
        {
            BattleSystem.instance.AllyTeam.AP++;
            BattleSystem.instance.AllyTeam.Draw();
            yield break;
        }
    }
}