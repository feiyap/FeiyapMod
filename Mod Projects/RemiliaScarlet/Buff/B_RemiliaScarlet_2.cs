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
    /// 绯色幻想
    /// 释放攻击技能时，对随机敌人重复释放1次。
    /// </summary>
    public class B_RemiliaScarlet_2:Buff, IP_SkillUseHand_Team
    {
        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
            this.PlusStat.DMGTaken = -20f;
            this.PlusStat.HIT_CC = 100f;
            this.PlusStat.HIT_DEBUFF = 100f;
            this.PlusStat.HIT_DOT = 100f;
        }

        public void SKillUseHand_Team(Skill skill)
        {
            if (skill.IsDamage && skill.Master == this.BChar)
            {
                BattleSystem.DelayInputAfter(BattleSystem.instance.SkillRandomUseIenum(skill.Master, skill.CloneSkill(true, skill.Master, null, false), false, false, false));
            }
        }
    }
}