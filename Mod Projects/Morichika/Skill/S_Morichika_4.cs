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
namespace Morichika
{
	/// <summary>
	/// 快速谈判
	/// 只能指向体力值百分比低于自身（当前为：&a%）的敌人。
	/// </summary>
    public class S_Morichika_4:Skill_Extended
    {
        public override bool TargetSelectExcept(BattleChar ExceptTarget)
        {
            return (!(ExceptTarget is BattleEnemy) || !(((ExceptTarget as BattleEnemy).HP * 100 / (ExceptTarget as BattleEnemy).GetStat.maxhp) <= (this.BChar.HP * 100 / this.BChar.GetStat.maxhp))) && ExceptTarget is BattleEnemy;
        }

        public override string DescExtended(string desc)
        {
            return base.DescExtended(desc).Replace("&a", ((int)(this.BChar.HP * 100 / this.BChar.GetStat.maxhp)).ToString());
        }
    }
}