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
namespace HouraisanKaguya
{
	/// <summary>
	/// 「永夜归返」
	/// 无法强化。
	/// 仅在自身拥有[辉夜/神宝]时才可使用，释放时消耗[辉夜/神宝]。
	/// 每次使用「永夜归返」后，「永夜归返」会获得永久增强。
	/// </summary>
    public class S_FKaguya_10Rare: SkillExtended_10Rare
    {
        //public override bool Terms()
        //{
        //    return this.BChar.BuffFind("B_FKaguya_Sinnpou");
        //}
        //public override void SkillUseSingle(Skill SkillD, List<BattleChar> Targets)
        //{
        //    base.SkillUseSingle(SkillD, Targets);
        //    CharInfoSkillData item = this.BChar.Info.SkillDatas.Find((CharInfoSkillData s) => s.Skill.KeyID == "S_FKaguya_10Rare");
        //    this.BChar.Info.SkillDatas.Remove(item);

        //    Skill skill = Skill.TempSkill("S_FKaguya_10Rare_0", this.BChar, BattleSystem.instance.AllyTeam);
        //    BattleSystem.instance.AllyTeam.Add(skill, true);
        //    this.BChar.Info.UseSoulStone(skill);

        //    if (this.BChar.BuffFind("B_FKaguya_Sinnpou"))
        //    {
        //        this.BChar.BuffReturn("B_FKaguya_Sinnpou").SelfDestroy();
        //    }
        //}
    }
}