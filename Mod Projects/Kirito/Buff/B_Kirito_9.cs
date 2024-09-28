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
namespace Kirito
{
	/// <summary>
	/// 十字格挡
	/// 受到攻击时反击。
	/// </summary>
    public class B_Kirito_9:Buff, IP_Hit, IP_Dodge
    {
        public override void BuffStat()
        {
            base.BuffStat();
            this.PlusStat.DMGTaken = -50f;
            this.PlusStat.Strength = true;
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            if (base.Usestate_L.IsDead)
            {
                base.SelfDestroy(false);
            }
        }

        public void Dodge(BattleChar Char, SkillParticle SP)
        {
            if (Char == this.BChar)
            {
                Skill skill = Skill.TempSkill("S_Kirito_9_0", base.Usestate_F, this.BChar.MyTeam);
                skill.PlusHit = true;
                BattleSystem.DelayInput(BattleSystem.instance.ForceAction(skill, SP.UseStatus, false, false, true, null));
            }
        }

        public void Hit(SkillParticle SP, int Dmg, bool Cri)
        {
            if (Dmg >= 1 && !SP.UseStatus.Info.Ally)
            {
                Skill skill = Skill.TempSkill("S_Kirito_9_0", base.Usestate_F, this.BChar.MyTeam);
                skill.PlusHit = true;
                BattleSystem.DelayInput(BattleSystem.instance.ForceAction(skill, SP.UseStatus, false, false, true, null));
            }
        }
    }
}