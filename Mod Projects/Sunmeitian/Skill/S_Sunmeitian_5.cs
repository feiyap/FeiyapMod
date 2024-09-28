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
namespace Sunmeitian
{
	/// <summary>
	/// 如意棒法
	/// 无法使用。
	/// 这个技能握在手中时，释放4个自己的技能后才可使用。
	/// </summary>
    public class S_Sunmeitian_5:Skill_Extended, IP_SkillUseHand_Team
    {
        public bool Flag;
        public int skillUseCount;

        public override void Init()
        {
            base.Init();
            this.OnePassive = true;
        }

        public override void HandInit()
        {
            base.HandInit();
            this.Flag = false;
            skillUseCount = 0;
        }

        public override bool Terms()
        {
            return this.Flag;
        }

        public void SKillUseHand_Team(Skill skill)
        {
            if (skill.Master == this.BChar)
            {
                skillUseCount++;
            }
            if (skillUseCount >= 4)
            {
                this.Flag = true;
            }
        }
    }
}