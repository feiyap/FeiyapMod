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
namespace SatsukiRin
{
	/// <summary>
	/// 薰风
	/// 下1次造成或受到的治疗效果+50%。
	/// </summary>
    public class B_Satsuki_0:Buff, IP_Healed
    {
        public override void Init()
        {
            base.Init();
            this.LucySkillExBuff = (BuffSkillExHand)Skill_Extended.DataToExtended("SE_Satsuki_0");
            this.PlusStat.HEALTaken = 50;
        }
        
        public override bool CanSkillBuffAdd(Skill AddedSkill, int Index)
        {
            return AddedSkill.Master == this.BChar && AddedSkill.IsHeal && AddedSkill.ExtendedFind_DataName("SE_Satsuki_0") == null;
        }

        public void Healed(BattleChar Healer, BattleChar HealedChar, int HealNum, bool Cri, int OverHeal)
        {
            if (HealNum >= 1)
            {
                this.LucySkillExBuff = null;
                base.SelfDestroy(false);
            }
        }
    }
}