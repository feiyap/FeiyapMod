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
namespace FFAce
{
	/// <summary>
	/// 苍蓝之冰
	/// 攻击单个敌人时，为目标施加1层[霜冻]。
	/// 当[苍蓝之冰]达到3层时，在手中生成1张[苍蓝之冰]并解除该增益。
	/// </summary>
    public class B_FFAce_5:Buff, IP_SkillUse_Target
    {
        public override void Init()
        {
            base.Init();
            if (this.StackNum == 3)
            {
                Skill tmpSkill = Skill.TempSkill("S_FFAce_5_Ex", this.Usestate_F, this.Usestate_F.MyTeam);
                tmpSkill.isExcept = true;
                BattleSystem.instance.AllyTeam.Add(tmpSkill, true);
                SelfDestroy();
            }
        }

        public void AttackEffect(BattleChar hit, SkillParticle SP, int DMG, bool Cri)
        {
            if (DMG >= 1 && SP.UseStatus.Info.Ally != hit.Info.Ally && !SP.SkillData.PlusHit && SP.ALLTARGET.Count == 1)
            {
                hit.BuffAdd("B_FFAce_5_1", this.BChar);
            }
        }
    }
}