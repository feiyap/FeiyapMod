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
namespace YorigamiSister
{
	/// <summary>
	/// 拜金主义
	/// 攻击力随着“自己身上所有装备品质之和”提升（每点品质提升10%）。
	/// 造成伤害后移除 1 层。
	/// </summary>
    public class B_Joon_4:Buff, IP_SkillUse_Team
    {
        public override void Init()
        {
            base.Init();
            this.PlusPerStat.Damage = P_YorigamiJoon.calculateTotalEquipQuality(this.BChar) * 10;
        }

        public void SkillUseTeam(Skill skill)
        {
            if (skill.Master == this.BChar)
            {
                this.SelfStackDestroy();
            }
        }
    }
}