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
namespace HolySaber
{
	/// <summary>
	/// 神的告诫
	/// 每回合第1次使用自己的技能时，获得1点进化点。
	/// </summary>
    public class B_HolySaber_7:Buff, IP_PlayerTurn, IP_SkillUseHand_Team
    {
        public bool isEffect = false;

        public override void Init()
        {
            base.Init();
            isEffect = false;
        }

        public void Turn()
        {
            isEffect = false;
        }

        public void SKillUseHand_Team(Skill skill)
        {
            if (!skill.BasicSkill && skill.Master == this.BChar && !isEffect)
            {
                isEffect = true;
                this.BChar.BuffAdd("B_HolySaber_P", this.BChar);
            }
        }
    }
}