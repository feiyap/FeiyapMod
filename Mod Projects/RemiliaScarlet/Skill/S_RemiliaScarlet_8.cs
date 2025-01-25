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
namespace RemiliaScarlet
{
    /// <summary>
    /// 诅咒「弗拉德·特佩斯的诅咒」
    /// 仅在自身拥有[吸血鬼之心]增益的时候才可使用。
    /// 消耗1层[吸血鬼之心]增益，获得&a(自身100%最大体力值)点防护墙。
    /// 消耗所有[摇篮曲] 增益，每消耗1层，额外获得&b(自身10%最大体力值)点防护墙；每消耗5层，抽取1个技能，恢复1点法力值。
	/// </summary>
    public class S_RemiliaScarlet_8:Skill_Extended
    {
        //public int BHP
        //{
        //    get
        //    {
        //        if (BattleSystem.instance == null || BattleSystem.instance.BattleLogs == null || BattleSystem.instance.TurnNum <= 0)
        //        {
        //            return 0;
        //        }
        //        return (int)((float)(0 + this.BChar.GetStat.maxhp * 1.0));
        //    }
        //}

        //public int BHP1
        //{
        //    get
        //    {
        //        if (BattleSystem.instance == null || BattleSystem.instance.BattleLogs == null || BattleSystem.instance.TurnNum <= 0)
        //        {
        //            return 0;
        //        }
        //        return (int)((float)(0 + this.BChar.GetStat.maxhp * 0.1));
        //    }
        //}

        //public override bool Terms()
        //{
        //    if (this.BChar.BuffFind("B_RemiliaScarlet_5", false) || this.BChar.BuffFind("B_RemiliaScarlet_1", false))
        //    {
        //        return true;
        //    }
        //    return false;
        //}

        //public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        //{
        //    base.SkillUseSingle(SkillD, Targets);

        //    if (this.BChar.BuffFind("B_RemiliaScarlet_5", false))
        //    {
        //        this.BChar.BuffReturn("B_RemiliaScarlet_5", false).SelfStackDestroy();
        //        BattleSystem.instance.AllyTeam.partybarrier.BarrierHP += this.BHP;
        //    }

        //    if (this.BChar.BuffFind("B_RemiliaScarlet_1", false))
        //    {
        //        int stacknum = this.BChar.BuffReturn("B_RemiliaScarlet_1", false).StackNum;
        //        int count = stacknum / 5;
        //        this.BChar.BuffReturn("B_RemiliaScarlet_1", false).SelfDestroy();
        //        BattleSystem.instance.AllyTeam.partybarrier.BarrierHP += this.BHP1 * stacknum;
        //        BattleSystem.instance.AllyTeam.AP += count;
        //        BattleSystem.instance.AllyTeam.Draw(count);
        //    }
        //}

        //public override string DescExtended(string desc)
        //{
        //    return base.DescExtended(desc).Replace("&a", (this.BHP).ToString()).Replace("&b", (this.BHP1).ToString());
        //}

        //public bool Flag;
    }
}