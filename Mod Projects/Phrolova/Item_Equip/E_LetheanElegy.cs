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
namespace Phrolova
{
	/// <summary>
	/// 幽冥的忘忧章
	/// 固定能力造成的伤害提升64%。
	/// 释放固定能力后，下 1 个从手中释放的技能造成的伤害提升64%。
	/// <i><color=#919191>我不在那里，也没有死去。
	/// 我将追随死亡，用享受掩盖恐惧，以未来换回过去。</color></i>
	/// </summary>
    public class E_LetheanElegy:EquipBase, IP_SkillUse_User
    {
        public override void Init()
        {
            this.OnePassive = true;
            this.PlusPerStat.Damage = 24;
            this.PlusStat.Penetration = 16;
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            if (BattleSystem.instance == null)
            {
                return;
            }
            if (BattleSystem.instance.TurnNum < 1)
            {
                return;
            }
            if (this.BChar is BattleAlly && (this.BChar as BattleAlly).MyBasicSkill.buttonData.ExtendedFind<SE_E_LetheanElegy>() == null)
            {
                (this.BChar as BattleAlly).MyBasicSkill.buttonData.ExtendedAdd(new SE_E_LetheanElegy());
            }
        }

        public void SkillUse(Skill SkillD, List<BattleChar> Targets)
        {
            if (SkillD.BasicSkill)
            {
                this.BChar.BuffAdd("B_LetheanElegy", this.BChar);
            }
        }
    }
}