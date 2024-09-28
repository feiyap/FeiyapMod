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
namespace Mokou
{
	/// <summary>
	/// 正直者的试炼
	/// 如果倒计时内没有受到攻击，则施加aoe攻击；如果受到攻击，对双方施加烧伤。
	/// </summary>
    public class B_Mokou_S_3:Buff, IP_Hit, IP_SkillUse_Target
    {
        public override string DescExtended()
        {
            return base.DescExtended().Replace("&a", (base.Usestate_F.GetStat.HIT_DOT + 100f).ToString());
        }
        public void Hit(SkillParticle SP, int Dmg, bool Cri)
        {
            if (Dmg > 0 && hitted == 0)
            {
                SP.UseStatus.BuffAdd("B_Mokou_T_1", this.BChar, false, 0, false, -1, false);
                SP.UseStatus.BuffAdd("B_Mokou_T_1", this.BChar, false, 0, false, -1, false);
                SP.UseStatus.BuffAdd("B_Mokou_T_1", this.BChar, false, 0, false, -1, false);
                this.BChar.BuffAdd("B_Mokou_T_1", this.BChar, false, 0, false, -1, false);
                this.BChar.BuffAdd("B_Mokou_T_1", this.BChar, false, 0, false, -1, false);
                this.BChar.BuffAdd("B_Mokou_T_1", this.BChar, false, 0, false, -1, false);
                this.hitted++;
            }
        }
        public void AttackEffect(BattleChar hit, SkillParticle SP, int DMG, bool Cri)
        {
            if (SP.SkillData.MySkill.KeyID == "S_Mokou_3")
            {
                this.BChar.BuffRemove("B_Mokou_S_3", false);
                base.SelfDestroy(false);
                if (hitted == 0)
                {
                    Skill skill = Skill.TempSkill("S_Mokou_3_0" , this.BChar, this.BChar.MyTeam);
                    skill.isExcept = true;
                    BattleSystem.instance.AllyTeam.Add(skill, true);
                    base.SelfStackDestroy();
                }
                hitted = 0;
            }
        }
        public override void FixedUpdate()
        {
            base.FixedUpdate();
            if (base.Usestate_L.IsDead)
            {
                base.SelfDestroy(false);
                this.BChar.BuffRemove("B_Mokou_S_3", false);
            }
        }
        public int hitted = 0;
    }
}