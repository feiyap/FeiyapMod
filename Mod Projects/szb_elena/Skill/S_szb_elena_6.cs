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
namespace szb_elena
{
	/// <summary>
	/// 圣痕的执行
	/// 对随机敌人造成&a伤害(本回合中自己回复生命值的次数 x 攻击力的30%)。
	/// </summary>
    public class S_szb_elena_6:Skill_Extended
    {
        public override string DescExtended(string desc)
        {
            return base.DescExtended(desc).Replace("&a", ((int)(this.BChar.GetStat.atk * 0.3 * P_szb_elena.TurnHealedNum)).ToString());
        }
        public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        {
            BattleSystem.instance.EnemyTeam.AliveChars.Random(this.BChar.GetRandomClass().Main).Damage(this.BChar, (int)(this.BChar.GetStat.atk * 0.3 * P_szb_elena.TurnHealedNum), false, false, false, 0, false, false, false);
        }
    }
}