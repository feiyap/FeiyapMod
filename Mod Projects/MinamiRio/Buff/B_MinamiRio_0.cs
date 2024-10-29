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
namespace MinamiRio
{
	/// <summary>
	/// <color=#DC143C>皆中</color>
	/// 攻击命中时获得1层<color=#DC143C>皆中</color>。
	/// <color=#48D1CC>单弓</color> - 层数达到上限时，移除该增益并优先抽取1个自己的技能。
	/// <color=#FFD700>和弓</color> - 层数达到上限时，移除该增益并获得[全神贯注]。
	/// </summary>
    public class B_MinamiRio_0:Buff, IP_SkillUse_Target
    {
        public override void Init()
        {
            this.PlusStat.hit = 5 * StackNum;
            if (base.StackNum == 3)
            {
                if (this.BChar.BuffFind("B_MinamiRio_P1"))
                {
                    BattleSystem.instance.AllyTeam.CharacterDraw(this.BChar, null);
                }
                else if (this.BChar.BuffFind("B_MinamiRio_P2"))
                {
                    this.BChar.BuffAdd("B_MinamiRio_2", this.BChar);
                }
                if ((this.BChar as BattleAlly).MyBasicSkill.buttonData.MySkill.KeyID == "S_MinamiRio_0")
                {
                    this.BChar.MyTeam.BasicSkillRefill(this.BChar, this.BChar.BattleBasicskillRefill);
                }
                this.SelfDestroy();
            }
        }

        public void AttackEffect(BattleChar hit, SkillParticle SP, int DMG, bool Cri)
        {
            if (hit.HP >= 1 && base.StackNum >= 1 && SP.SkillData.IsDamage && SP.SkillData.Master == this.BChar)
            {
                this.BChar.BuffAdd("B_MinamiRio_0", this.BChar);
            }
        }
    }
}