using ChronoArkMod;
using ChronoArkMod.Plugin;
using ChronoArkMod.Template;
using DarkTonic.MasterAudio;
using GameDataEditor;
using I2.Loc;
using Spine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;
namespace HiHouClab
{
	/// <summary>
	/// 专注模式
	/// 下 1 个非迅速的攻击技能造成 &a 额外伤害(攻击力的100%)。
	/// </summary>
    public class B_Renko_P_1:Buff
    {
        public override void FixedUpdate()
        {
            base.FixedUpdate();
            this.LucySkillExBuff = (BuffSkillExHand)Skill_Extended.DataToExtended("SE_Renko_P");
        }

        public override bool CanSkillBuffAdd(Skill AddedSkill, int Index)
        {
            return AddedSkill.Master == this.BChar && AddedSkill.IsDamage && !AddedSkill.NotCount && AddedSkill.ExtendedFind_DataName("SE_Renko_P") == null;
        }

        //public void SKillUseHand_Team(Skill skill)
        //{
        //    if (skill.Master == this.BChar && skill.IsDamage && !skill.NotCount)
        //    {
        //        BattleSystem.DelayInput(this.Delete());
        //    }
        //}

        //public IEnumerator Delete()
        //{
        //    base.SelfDestroy(false);
        //    yield return null;
        //    yield break;
        //}

        public override string DescInit()
        {
            return base.DescInit().Replace("&a", ((int)(this.BChar.GetStat.atk * 1.0)).ToString());
        }
    }
}